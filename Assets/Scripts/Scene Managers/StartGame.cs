using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] GameObject game;
    [SerializeField] PlayerList playerList;

    public void StartNewGame()
    {
        StartCoroutine(PlayClickSoundAndLoadNewGame());
    }

    IEnumerator PlayClickSoundAndLoadNewGame()
    {
        audioPlayer.PlayButtonClickSound();
        yield return new WaitUntil(() => audioPlayer.audioSource.isPlaying == false);
        playerList.ReadPlayersNames();
        game.SetActive(true);
        gameObject.SetActive(false);
    }
}
