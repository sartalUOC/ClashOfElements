using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numFichaJugador : MonoBehaviour
{
    // Número de la ficha
    public int idFicha;

    // Asignación de texturas posibles de las fichas
    public Texture texturaMaderaBlanca;
    public Texture texturaAguaBlanca;
    public Texture texturaFuegoBlanca;
    public Texture texturaMaderaNegra;
    public Texture texturaAguaNegra;
    public Texture texturaFuegoNegra;

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
