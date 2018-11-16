using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioPlayer audioPlayer;

    public void StartNewGame()
    {
        GetComponent<PlayerCreator>().CreatePlayers();
        StartCoroutine(PlayClickSoundAndLoadNewGame());
    }

    IEnumerator PlayClickSoundAndLoadNewGame()
    {
        audioPlayer.PlayButtonClickSound();
        yield return new WaitUntil(() => audioPlayer.audioSource.isPlaying == false);
        SceneManager.LoadScene("Game");
    }
}
