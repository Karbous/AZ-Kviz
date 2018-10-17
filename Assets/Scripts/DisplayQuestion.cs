using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour
{
    [SerializeField] Text questionText;
    [SerializeField] GameObject correctButton;
    [SerializeField] GameObject wrongButton;
    [SerializeField] GameObject notAnsweredButton;
    [SerializeField] Text titleText;   

    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] PlayerList myPlayerList;

    //TMP
    [SerializeField] GameObject tile;

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
        DisplayCorrectWrongButtons();
        DisplayQuestionText();
    }

    public void CorrectAnswer()
    {
        //TO DO change state and color of the tile to player who answer correctly
        tile.GetComponent<TileState>().tileState = activePlayer.PlayerIndex;
        tile.GetComponent<SpriteRenderer>().color = activePlayer.Color;


        ChangeActivePlayer();
        CleanQuestion();
    }


    public void WrongAnswer()
    {
        if (activePlayer == firstToAnswer)
        {
            OfferQuestionToOtherPlayer();
        }
        else
        {
            //TO DO changestate and color of tile to substitute
            tile.GetComponent<TileState>().tileState = 2;
            tile.GetComponent<SpriteRenderer>().color = Color.gray;



            ChangeActivePlayer();
            CleanQuestion();
        }
    }

    public void NotAnswered()
    {
        //TO DO changestate and color of tile to substitute
        tile.GetComponent<TileState>().tileState = 2;
        tile.GetComponent<SpriteRenderer>().color = Color.gray;


        CleanQuestion();
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
