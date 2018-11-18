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
    [SerializeField] PlayAgain playAgain;
    [SerializeField] AudioPlayer audioPlayer;

    [HideInInspector] public string theWinnerIs;

    private void OnEnable()
    {
        playAgain.resetGame += ResetGame;
    }

    public void WeHaveWinner()
    {
        BlockAllTiles();
        HideActivePlayerText();
        ShowWinningScreen();
        ShowButton();
        audioPlayer.PlayWinnerSound();
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

    private void ShowButton()
    {
        playAgainButton.SetActive(true);
    }

    private void ResetGame()
    {
        winnerText.text = "";
        activePlayerText.enabled = true;
    }

    private void OnDisable()
    {
        playAgain.resetGame += ResetGame;
    }

}
