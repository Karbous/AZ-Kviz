using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreator : MonoBehaviour {

    [SerializeField] PlayerList playerList;
    [SerializeField] GameObject player1Name;
    [SerializeField] GameObject player2Name;


    public void CreatePlayers()
    {
        playerList.players[0] = new Player(player1Name.GetComponent<InputField>().text, Color.red);
        playerList.players[1] = new Player(player2Name.GetComponent<InputField>().text, Color.blue);
	}

}
