using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileNumber : MonoBehaviour {

    [SerializeField] Tile tile;

	void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = tile.tileNumber.ToString();
	}

    public void HideNumber()
    {
        GetComponent<TextMeshProUGUI>().text = "";
    }
}
