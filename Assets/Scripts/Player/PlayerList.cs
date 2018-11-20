using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerList : MonoBehaviour
{
    public Player[] players = new Player[2];
    [SerializeField] TextMeshProUGUI player1Name;
    [SerializeField] TextMeshProUGUI player2Name;
    [SerializeField] PlayAgain playAgain;
    [SerializeField] Color player1Color;
    [SerializeField] Color player2Color;
    public Color clickedTile;
    public Color substituteTile;


    public int activePlayerIndex = 0;

    private void Awake()
    {
        players[0] = new Player(player1Color);
        players[1] = new Player(player2Color);
    }

    private void OnEnable()
    {
        playAgain.resetGame += ClearEdgeTiles;
    }

    public void SwitchActivePlayer()
    {
        if (activePlayerIndex == 0) activePlayerIndex = 1;
        else activePlayerIndex = 0;
    }

    public void ReadPlayersNames()
    {
        players[0].Name = player1Name.text;
        players[1].Name = player2Name.text;
    }

    private void ClearEdgeTiles()
    {
        foreach (Player player in players)
        {
            player.ClearEdgeTiles();
        }
    }

    private void OnDisable()
    {
        playAgain.resetGame -= ClearEdgeTiles;
    }

}
