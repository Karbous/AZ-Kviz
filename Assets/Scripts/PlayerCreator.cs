using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour {

    [SerializeField] PlayerList playerList;

	void Awake()
    {
        playerList.players[0] = new Player("Player 1", Color.red);
        playerList.players[1] = new Player("Player 2", Color.blue);
	}

}
