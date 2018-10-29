using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player List")]
public class PlayerList : ScriptableObject
{
    public Player[] players = new Player[2];

    public int activePlayerIndex = 0;

    public void SwitchActivePlayer()
    {
        if (activePlayerIndex == 0) activePlayerIndex = 1;
        else activePlayerIndex = 0;
    }

    public void AddTileToEdgeTiles(int tileNumber)
    {
        players[activePlayerIndex].EdgeTiles.Add(tileNumber);
    }
}
