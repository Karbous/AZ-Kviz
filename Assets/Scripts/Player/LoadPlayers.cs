using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayers : MonoBehaviour
{
    [SerializeField] GameObject intro;
    [SerializeField] GameObject players;

    public void LoadPlayersUI()
    {
        intro.SetActive(false);
        players.SetActive(true);
    }
	
}
