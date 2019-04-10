using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Siguiente : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        int[,] fichasjugador = null;
        int totalFichasAsignadas = 0;
        if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
        {
            fichasjugador = FichaSeleccionada.GetFichasJugador1();
        }
        if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
        {
            fichasjugador = FichaSeleccionada.GetFichasJugador2();
        }

        for (int i = 0; i < 9; i++)
        {
            if (fichasjugador[i, 3] > 0)
            {
                totalFichasAsignadas ++;
            }
        }

        if (totalFichasAsignadas > 8)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }
        
    }

    // Borra la selección de fichas y elementos del jugador 1
    public void GuardaFichasJugador1()
    {
        GameObject[] fichas;

        // Indica como desmarcadas todas las fichas del jugador 1
        FichaSeleccionada.InicializaFichasSeleccionadas();

        // Añadimos al array todas las fichas del jugador 1
        fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");

        foreach (GameObject ficha in fichas)
        {
            // recorremos todas las fichas quitando el elemento y la selección
            this.QuitaMaterial(ficha);
            this.PintaBlanco(ficha);
        }

        // Inicializamos el elemento seleccionado
        ElementoSeleccionado.SetElementoSeleccionado(0);
        // Limpiamos la selección de elemento
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Fuego"));
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Agua"));
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Madera"));

    }

    // Borra la selección de fichas y elementos del jugador 2
    public void GuardaFichasJugador2()
    {
        GameObject[] fichas;

        // Indica como desmarcadas todas las fichas del jugador 1
        FichaSeleccionada.InicializaFichasSeleccionadas();

        // Añadimos al array todas las fichas del jugador 1
        fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");

        foreach (GameObject ficha in fichas)
        {
            // recorremos todas las fichas quitando el elemento y la selección
            this.QuitaMaterial(ficha);
            this.PintaGris(ficha);
        }

        // Inicializamos el elemento seleccionado
        ElementoSeleccionado.SetElementoSeleccionado(0);
        // Limpiamos la selección de elemento
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Fuego"));
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Agua"));
        this.PintaBlanco(GameObject.FindGameObjectWithTag("Madera"));

    }

    // Quita el material que hace referencia al elemento de un objeto
    private void QuitaMaterial(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = null;
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

    // Pone el objeto de color gris
    private void PintaGris(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.grey;
            r.material = m;
        }
    }
}
