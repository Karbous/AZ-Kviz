using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public delegate void ResetGame();
    public event ResetGame resetGame;

    private void Start()
    {
        resetGame += HidePlayAgainButton;
    }

    private void HidePlayAgainButton()
    {
        gameObject.SetActive(false);
    }

    public void ResetGameWhenClicked()
    {
        resetGame();
    }
}
