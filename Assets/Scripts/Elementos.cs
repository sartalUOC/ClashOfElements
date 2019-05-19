using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elementos : MonoBehaviour
{
    // Identifica el elemento de las fichs de selección de elementos
    public int idElemento; // 1, 2 o 3 - Fuego, Agua o Madera
    // Sonido selección
    public AudioClip selectSound;

    AudioSource audioSource;

    private void Start()
    {
        // Inicializamos el audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Activamos el sonido de selección
    public void SonidoSeleccion()
    {
        audioSource.PlayOneShot(selectSound);
    }


}
