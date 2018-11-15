using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCreator : MonoBehaviour {

    [SerializeField] PlayerList playerList;
    [SerializeField] TextMeshProUGUI player1Name;
    [SerializeField] TextMeshProUGUI player2Name;


    public void CreatePlayers()
    {
        playerList.players[0] = new Player(player1Name.text, Color.red);
        playerList.players[1] = new Player(player2Name.text, Color.blue);
	}

}
