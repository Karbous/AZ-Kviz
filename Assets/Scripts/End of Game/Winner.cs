using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField] PlayerList myPlayerList;
    [SerializeField] Tiles allTiles;
    [SerializeField] GameEnd gameEnd;
    [SerializeField] PlayAgain playAgain;

    Queue<Tile> neigborsToBeSearched = new Queue<Tile>();
    List<Tile> tilesOwnedByPlayer = new List<Tile>();

    bool leftEdge = false;
    bool rightEdge = false;
    bool bottomEdge = false;
    bool weHaveWinner = false;

    private void OnEnable()
    {
        playAgain.resetGame += ResetForNewGame;
    }

    public void CheckWinnerConditions()
    {
        List<int> playerEdgeTiles = myPlayerList.players[myPlayerList.activePlayerIndex].EdgeTiles;

        foreach (int tileNumber in playerEdgeTiles)
        {
            tilesOwnedByPlayer.Clear();
            leftEdge = rightEdge = bottomEdge = false; 
            Tile startingTile = allTiles.tiles[tileNumber - 1];
            SearchAllNeighboursIfOwnedByPlayer(startingTile);
            CheckIfPlayerWins();
            if (weHaveWinner)
            {
                break;
            }
        }
    }

    private void SearchAllNeighboursIfOwnedByPlayer(Tile startingTile)
    {
        tilesOwnedByPlayer.Add(startingTile);
        AddNeighborsToBeSearched(startingTile);

        while (neigborsToBeSearched.Count > 0)
        {
            Tile neighbor = neigborsToBeSearched.Dequeue();
            if (neighbor.tileState == myPlayerList.activePlayerIndex)
            {
                tilesOwnedByPlayer.Add(allTiles.tiles[neighbor.tileNumber - 1]);
                AddNeighborsToBeSearched(neighbor);
            }
        }
    }

    private void AddNeighborsToBeSearched(Tile startingTile)
    {
        foreach (int neighborTileNumber in startingTile.neighbors)
        {
            Tile neighborTile = allTiles.tiles[neighborTileNumber - 1];
            if (!tilesOwnedByPlayer.Contains(neighborTile) && !neigborsToBeSearched.Contains(neighborTile))
            {
                neigborsToBeSearched.Enqueue(neighborTile);
            }
        }
    }

    private void CheckIfPlayerWins()
    {
        if (tilesOwnedByPlayer.Count >= 7)
        {
            foreach (Tile tile in tilesOwnedByPlayer)
            {
                if (tile.leftEdge)
                    leftEdge = true;

                if (tile.rightEdge)
                    rightEdge = true;

                if (tile.bottomEdge)
                    bottomEdge = true;

                if (leftEdge && rightEdge && bottomEdge)
                {
                    weHaveWinner = true;
                    gameEnd.WeHaveWinner();
                    break;
                }
            }
        }
    }

    private void ResetForNewGame()
    {
        weHaveWinner = false;
    }

    private void OnDisable()
    {
        playAgain.resetGame -= ResetForNewGame;
    }

}
