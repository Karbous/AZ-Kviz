using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int PlayerIndex;
    public string PlayerName;
    public Color Color;

    public Player(string playerName, Color color)
    {
        this.PlayerName = playerName;
        this.Color = color;
    }
}
