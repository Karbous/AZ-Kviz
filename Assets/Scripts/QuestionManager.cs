using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] PlayerList myPlayerList;

    Player firstToAnswer;
    Player activePlayer;
    QuestionUI questionUI;

    public delegate void ChangeTile(int newTileState, Color newTileColor);
    public event ChangeTile changeTile;

    public delegate void BlockOrUnblockTile();
    public event BlockOrUnblockTile blockOrUnblockTile;

    private void Start()
    {
        questionUI = GetComponent<QuestionUI>();
        LoadActivePlayer();
        questionUI.CleanQuestion(activePlayer);
    }

    public void NewQuestion()
    {
        BlockAllTiles();
        LoadActivePlayer();
        firstToAnswer = activePlayer;
        questionUI.DisplayNewQuestion();
    }

    public void CorrectAnswer()
    {
        if (changeTile != null)
        {
            changeTile(myPlayerList.activePlayerIndex, activePlayer.Color);
        }
        ChangeActivePlayer();
        questionUI.CleanQuestion(activePlayer);
        UnBlockAllTiles();
    }


    public void WrongAnswer()
    {
        if (activePlayer == firstToAnswer)
        {
            ChangeActivePlayer();
            questionUI.QuestionForOtherPlayer(activePlayer);
        }
        else
        {
            if (changeTile != null)
            {
                changeTile(2, Color.gray);
            }
            ChangeActivePlayer();
            questionUI.CleanQuestion(activePlayer);
            UnBlockAllTiles();
        }
    }

    public void NotAnswered()
    {
        if (changeTile != null)
        {
            changeTile(2, Color.gray);
        }
        questionUI.CleanQuestion(activePlayer);
        UnBlockAllTiles();
    }


    private void ChangeActivePlayer()
    {
        myPlayerList.SwitchActivePlayer();
        LoadActivePlayer();
    }

    private void LoadActivePlayer()
    {
        activePlayer = myPlayerList.players[myPlayerList.activePlayerIndex];
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
}
