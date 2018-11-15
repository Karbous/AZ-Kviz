using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] PlayerList playerList;
    [SerializeField] Tiles tiles;
    [SerializeField] TextMeshProUGUI activePlayerText;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] GameObject quitButton;

    public string theWinnerIs;

    public void WeHaveWinner()
    {
        BlockAllTiles();
        HideActivePlayerText();
        ShowWinningScreen();
        ShowButtons();
    }

    private void BlockAllTiles()
    {
        foreach (Tile tile in tiles.tiles)
        {
            tile.isBlocked = true;
        }
    }

    private void ShowWinningScreen()
    {
        string winnerName = playerList.players[playerList.activePlayerIndex].Name;
        winnerText.text = theWinnerIs + ": " + winnerName;
    }

    private void HideActivePlayerText()
    {
        activePlayerText.enabled = false;
    }

    private void ShowButtons()
    {
        playAgainButton.SetActive(true);
        quitButton.SetActive(true);
    }
}
