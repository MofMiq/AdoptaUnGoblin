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

    // public void SeleccionAudio(int indice, float volume, int wait)
    // {
    //     yield return new WaitForSeconds(wait);
    //     controlAudio.PlayOneShot(audios[indice], volume);
    // }
    public void SeleccionAudio(int indice, float volume, int wait)
    {
        StartCoroutine(PlayAudioAfterDelay(indice, volume, wait));
    }

    private IEnumerator PlayAudioAfterDelay(int indice, float volume, int wait)
    {
        yield return new WaitForSeconds(wait);
        controlAudio.PlayOneShot(audios[indice], volume);
    }

}
