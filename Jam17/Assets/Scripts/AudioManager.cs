using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios; 

    private AudioSource controlAudio;
    private AudioManager audioManager;

    public void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void SeleccionAudio(int indice, float volume)
    {
        controlAudio.PlayOneShot(audios[indice], volume);
    }

}
