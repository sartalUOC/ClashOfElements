using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    // Salir del juego
    public void QuitGame()
    {
        // Sonido botón menú
        this.GetComponent<SonidoMenu>().SonidoSeleccionMenu();
        // Salir del juego
        Application.Quit();
    }
}
