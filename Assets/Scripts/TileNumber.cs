using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileNumber : MonoBehaviour {

    [SerializeField] Tile tile;

	void Awake()
    {
        GetComponent<Text>().text = tile.tileNumber.ToString();
	}

    public void HideNumber()
    {
        GetComponent<Text>().text = "";
    }
}
