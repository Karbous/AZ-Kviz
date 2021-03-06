﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField] AudioPlayer audioPlayer;

    public void QuitGame()
    {
        StartCoroutine(PlayClickSoundAndQuitGame());
    }

    IEnumerator PlayClickSoundAndQuitGame()
    {
        audioPlayer.PlayButtonClickSound();
        yield return new WaitUntil(() => audioPlayer.audioSource.isPlaying == false);
        Application.Quit();
    }
}
