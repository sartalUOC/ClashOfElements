using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaSeleccion : MonoBehaviour
{
    // Al iniciar pone las fichas con los elementos correspondientes si ya se habían seleccionado
    void Start()
    {
        GameObject[] fichas = null;
        int[,] datosFichas = null;
        // Añadimos al array todas las fichas del jugador 1
        if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            datosFichas = FichaSeleccionada.GetFichasJugador1();
        }
        // Añadimos al array todas las fichas del jugador 2
        if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            datosFichas = FichaSeleccionada.GetFichasJugador2();
        }

        foreach (GameObject ficha in fichas)
        {
            // recorremos todas las fichas asignando el elemento y añadiendo a las fichas seleccionadas
            if (datosFichas[(ficha.GetComponent<numFichaJugador>().idFicha) - 1, 3] == 1)
            {
                this.AsignaFuego(ficha);
                this.PintaBlanco(ficha);
            }

            if (datosFichas[(ficha.GetComponent<numFichaJugador>().idFicha) - 1, 3] == 2)
            {
                this.AsignaAgua(ficha);
                this.PintaBlanco(ficha);
            }

            if (datosFichas[(ficha.GetComponent<numFichaJugador>().idFicha) - 1, 3] == 3)
            {
                this.AsignaMadera(ficha);
                this.PintaBlanco(ficha);
            }

         }
    }

    // Pone el material de madera al objeto
    private void AsignaMadera(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaMadera;
            r.material = m;
        }
    }

    // Pone el material de agua al objeto
    private void AsignaAgua(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaAgua;
            r.material = m;
        }
    }

    // Pone el material de fuego al objeto
    private void AsignaFuego(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaFuego;
            r.material = m;
        }
    }

    // Pone el objeto de color blanco
    private void PintaBlanco(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }
    }
}
