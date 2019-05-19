using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMenu : MonoBehaviour
{
    // Sonido selección menu
    public AudioClip selectMenuSound;

    AudioSource audioSource;

    private void Start()
    {
        // Inicializamos el audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Activamos el sonido de selección
    public void SonidoSeleccionMenu()
    {
        audioSource.PlayOneShot(selectMenuSound);
        
    }

}
