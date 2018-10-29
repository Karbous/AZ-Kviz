using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name;
    public Color Color;
    public List<int> EdgeTiles;

    public Player(string name, Color color)
    {
        this.Name = name;
        this.Color = color;
        this.EdgeTiles = new List<int>();
    }
}
