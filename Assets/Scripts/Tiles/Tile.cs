using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] QuestionManager questionManager;
    [SerializeField] PlayerList myPlayerList;
    [SerializeField] Winner winner;
    [SerializeField] TileNumber tileNumberText;
    [SerializeField] AudioPlayer audioPlayer;
    public bool isBlocked = false;
    public int tileNumber;
    public int[] neighbors;

    public bool leftEdge = false;
    public bool rightEdge = false;
    public bool bottomEdge = false;

    public int tileState = -1;
    /*
    -1   tile is free
    0   tile is taken by player 1
    1   tile is taken by player 2
    2   tile has a substitute question
    */

    private void OnEnable()
    {
        questionManager.blockOrUnblockTile += BlockOrUnblockTile;
    }


    private void ChangeTile(int newTileState, Color newTileColor)
    {
        questionManager.changeTile -= ChangeTile;
        tileState = newTileState;
        GetComponent<SpriteRenderer>().color = newTileColor;
        if (tileState != 2)
        {
            tileNumberText.HideNumber();
            CheckForWinner();
        }
    }

    private void CheckForWinner()
    {
        if (leftEdge || rightEdge || bottomEdge)
        {
            myPlayerList.players[myPlayerList.activePlayerIndex].AddTileToEdgeTiles(tileNumber);
        }
        winner.CheckWinnerConditions();
    }

    private void OnMouseDown()
    {
        if ((tileState == -1 || tileState == 2) && isBlocked == false)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            questionManager.changeTile += ChangeTile;
            StartCoroutine(PlayClickSoundAndLoadNewQuestion());
        }
    }

    IEnumerator PlayClickSoundAndLoadNewQuestion()
    {
        audioPlayer.PlayTileClickSound();
        yield return new WaitUntil(() => audioPlayer.audioSource.isPlaying == false);
        questionManager.NewQuestion(tileState);
    }



    private void BlockOrUnblockTile()
    {
        isBlocked = !isBlocked;
    }

    private void OnDisable()
    {
        questionManager.blockOrUnblockTile -= BlockOrUnblockTile;
    }
}
