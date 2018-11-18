using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name;
    public Color Color;
    public List<int> EdgeTiles;

    public Player(Color color)
    {
        this.Color = color;
        this.EdgeTiles = new List<int>();
    }

    public void AddTileToEdgeTiles(int tileNumber)
    {
        EdgeTiles.Add(tileNumber);
    }

    public void ClearEdgeTiles()
    {
        EdgeTiles.Clear();
    }
}
