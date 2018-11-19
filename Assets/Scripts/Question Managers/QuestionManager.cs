using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] PlayerList myPlayerList;
    [SerializeField] Timer timer;
    [SerializeField] AudioPlayer audioPlayer;

    Player firstToAnswer;
    Player activePlayer;
    QuestionUI questionUI;
    int currentTileState = -1;

    public delegate void ChangeTile(int newTileState, Color newTileColor);
    public event ChangeTile changeTile;

    public delegate void BlockOrUnblockTile();
    public event BlockOrUnblockTile blockOrUnblockTile;

    private void OnEnable()
    {
        questionUI = GetComponent<QuestionUI>();
        LoadActivePlayer();
        questionUI.DisplayActivePlayer(activePlayer);
    }

    public void NewQuestion(int tileState)
    {
        currentTileState = tileState;
        BlockAllTiles();
        LoadActivePlayer();
        firstToAnswer = activePlayer;
        questionUI.DisplayNewQuestion(currentTileState);
    }

    public void CorrectAnswerWithSound()
    {
        audioPlayer.PlayCorrectSound();
        CorrectAnswer();
    }

    private void CorrectAnswer()
    {
        timer.StopTimer();
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
        timer.StopTimer();
        if (currentTileState == -1)
        {
            audioPlayer.PlayWrongSound();
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
        else
        {
            audioPlayer.PlayWrongSound();
            ChangeActivePlayer();
            CorrectAnswer();
        }
    }

    public void NotAnswered()
    {
        audioPlayer.PlayNotAnswered();
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
