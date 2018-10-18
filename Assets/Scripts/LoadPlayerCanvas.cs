using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayerCanvas : MonoBehaviour
{
    [SerializeField] GameObject introCanvas;
    [SerializeField] GameObject playersCanvas;

    public void LoadPlayersCanvas()
    {
        introCanvas.SetActive(false);
        playersCanvas.SetActive(true);
    }
	
}
