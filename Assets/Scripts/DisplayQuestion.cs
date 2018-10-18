using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour
{
    //TO DO must be refactored, it is handling too many things

    [SerializeField] Text questionText;
    [SerializeField] GameObject correctButton;
    [SerializeField] GameObject wrongButton;
    [SerializeField] GameObject notAnsweredButton;
    [SerializeField] Text titleText;   

    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] PlayerList myPlayerList;

    public delegate void ChangeTile(int newTileState, Color newTileColor);
    public event ChangeTile changeTile;

    public delegate void BlockOrUnblockTile();
    public event BlockOrUnblockTile blockOrUnblockTile;


    Player firstToAnswer;
    Player activePlayer;



    private void Start()
    {
        DisplayActivePlayer();
        ClearQuestionText();
    }

    public void DisplayNewQuestion()
    {
        activePlayer = myPlayerList.players[myPlayerList.activePlayerIndex];
        firstToAnswer = activePlayer;
        BlockAllTiles();
        DisplayCorrectWrongButtons();
        DisplayQuestionText();
    }

    private void BlockAllTiles()
    {
        if (blockOrUnblockTile != null)
        {
            blockOrUnblockTile();
        }
    }

    private void UnBlockAllTiles()
    {
        if (blockOrUnblockTile != null)
        {
            blockOrUnblockTile();
        }
    }



    public void CorrectAnswer()
    {
        if (changeTile != null)
        {
            changeTile(activePlayer.PlayerIndex, activePlayer.Color);
        }
        ChangeActivePlayer();
        CleanQuestion();
        UnBlockAllTiles();
    }


    public void WrongAnswer()
    {
        if (activePlayer == firstToAnswer)
        {
            OfferQuestionToOtherPlayer();
        }
        else
        {
            if (changeTile != null)
            {
                changeTile(2, Color.gray);
            }
            ChangeActivePlayer();
            CleanQuestion();
            UnBlockAllTiles();
        }
    }

    public void NotAnswered()
    {
        if (changeTile != null)
        {
            changeTile(2, Color.gray);
        }
        CleanQuestion();
        UnBlockAllTiles();
    }


    private void OfferQuestionToOtherPlayer()
    {
        ChangeActivePlayer();
        DisplayActivePlayer();
        AddNotAnsweredButton();
    }

    private void AddNotAnsweredButton()
    {
        notAnsweredButton.SetActive(true);
    }

    private void CleanQuestion()
    {
        DisplayActivePlayer();
        HideAllButtons();
        ClearQuestionText();
    }

    private void DisplayActivePlayer()
    {
        activePlayer = myPlayerList.players[myPlayerList.activePlayerIndex];
        titleText.text = activePlayer.PlayerName;
        titleText.color = activePlayer.Color;
    }

    private void DisplayCorrectWrongButtons()
    {
        correctButton.SetActive(true);
        wrongButton.SetActive(true);
    }

    private void ChangeActivePlayer()
    {
        myPlayerList.SwitchActivePlayer();
    }

    private void ClearQuestionText()
    {
        questionText.text = "";
    }

    private void HideAllButtons()
    {
        correctButton.SetActive(false);
        wrongButton.SetActive(false);
        notAnsweredButton.SetActive(false);
    }


    private void DisplayQuestionText()
    {
        if (mainQuestionList.list.Count > 0)
        {
            questionText.text = mainQuestionList.list[0];
            mainQuestionList.list.RemoveAt(0);
        }
    }



}
