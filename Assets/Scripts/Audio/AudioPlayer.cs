using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;

    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip tileClick;
    [SerializeField] AudioClip wrongButton;
    [SerializeField] AudioClip correctButton;
    [SerializeField] AudioClip winner;
    [SerializeField] AudioClip timerTicking;
    [SerializeField] AudioClip timerStop;
    [SerializeField] AudioClip notAnsweredButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        PlaySound(buttonClick);
    }

    public void PlayTileClickSound()
    {
        PlaySound(tileClick);
    }

    public void PlayWrongSound()
    {
        PlaySound(wrongButton);
    }

    public void PlayCorrectSound()
    {
        PlaySound(correctButton);
    }

    public void PlayWinnerSound()
    {
        PlaySound(winner);
    }

    public void PlayTimerTicking()
    {
        PlaySound(timerTicking);
    }

    public void PlayTimerStop()
    {
        PlaySound(timerStop);
    }

    public void PlayNotAnswered()
    {
        PlaySound(notAnsweredButton);
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
