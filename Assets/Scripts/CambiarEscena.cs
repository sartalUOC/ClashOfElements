using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscena : MonoBehaviour
{

    // Texto del botón para el cambio de cara
    public Text textoBoton;

    // Dependiendo de la cara que estemos seleccionano se cambia el texto
    private void Update()
    {
        if (FichaSeleccionada.GetCara() == 0 && textoBoton != null)
        {
            textoBoton.text = "Cara 1";
        }
        if (FichaSeleccionada.GetCara() == 1 && textoBoton != null)
        {
            textoBoton.text = "Cara 2";
        }
    }

    // Para cargar la escena que se indique como parámetro
    public void LoadScene(string SceneName)
    {
        // Sonido botón menú
        this.GetComponent<SonidoMenu>().SonidoSeleccionMenu();
        //Pausa para que de tiempo al sonido
        StartCoroutine(PausaSonido(SceneName));
    }

    IEnumerator PausaSonido(string SceneName)
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(SceneName);
    }

    // Selección jugador 1
    public void SetJugador1()
    {
        FichaSeleccionada.SetJugador(0);
    }
    
    // Selección jugador 2
    public void SetJugador2()
    {
        FichaSeleccionada.SetJugador(1);
    }

    // Seleccionamos la cara principal
    public void SetCara0()
    {
        FichaSeleccionada.SetCara(0);
    }

    // Seleccionamos la cara secundaria
    public void SetCara1()
    {
        FichaSeleccionada.SetCara(1);
    }

    // Cambiar cara seleccionada
    public void SetCara()
    {
        if (FichaSeleccionada.GetCara() == 0 )
        {
            FichaSeleccionada.SetCara(1);
            FichaSeleccionada.InicializaFichasSeleccionadas();
            ElementoSeleccionado.SetElementoSeleccionado(0);
        }
        else
        {
            FichaSeleccionada.SetCara(0);
            FichaSeleccionada.InicializaFichasSeleccionadas();
            ElementoSeleccionado.SetElementoSeleccionado(0);
        }
    }

    // No salir
    public void NoSalir()
    {
        IniciaPartida.panelSalir.SetActive(false);
        IniciaPartida.estaPausado = 0;
    }

    // Activar Menú Salir
    public void ActivarSalir()
    {
        IniciaPartida.panelSalir.SetActive(true);
        IniciaPartida.estaPausado = 1;
    }

}
