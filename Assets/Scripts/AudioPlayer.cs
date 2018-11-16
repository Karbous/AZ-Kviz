using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;

    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip tileClick;

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






    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
