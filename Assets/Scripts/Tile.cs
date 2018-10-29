using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] DisplayQuestion displayQuestion;
    [SerializeField] PlayerList myPlayerList;
    [SerializeField] Winner winner;
    [SerializeField] private bool isBlocked = false;
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
        displayQuestion.blockOrUnblockTile += BlockOrUnblockTile;
    }


    private void ChangeTile(int newTileState, Color newTileColor)
    {
        displayQuestion.changeTile -= ChangeTile;
        tileState = newTileState;
        GetComponent<SpriteRenderer>().color = newTileColor;
        CheckForTheWinner();
    }

    private void CheckForTheWinner()
    {
        if (leftEdge || rightEdge || bottomEdge)
        {
            myPlayerList.AddTileToEdgeTiles(tileNumber);
        }
        winner.CheckWinnerConditions();
    }

    private void OnMouseDown()
    {
        if (tileState == -1 && isBlocked == false)
        {
            displayQuestion.changeTile += ChangeTile;
            displayQuestion.DisplayNewQuestion();
        }
    }

    private void BlockOrUnblockTile()
    {
        isBlocked = !isBlocked;
    }

    private void OnDisable()
    {
        displayQuestion.blockOrUnblockTile -= BlockOrUnblockTile;
    }
}
