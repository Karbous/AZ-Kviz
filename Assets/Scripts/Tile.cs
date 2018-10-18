using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] DisplayQuestion displayQuestion;
    [SerializeField] private bool isBlocked = false;
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
