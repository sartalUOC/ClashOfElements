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
        int[,,] fichasjugador = null;
        int totalFichasAsignadas = 0;
        fichasjugador = FichaSeleccionada.GetFichasJugadores();

        for (int i = 0; i < 9; i++)
        {
            if (fichasjugador[FichaSeleccionada.GetJugador(), i, 0] > 0)
            {
                totalFichasAsignadas ++;
            }
            if (fichasjugador[FichaSeleccionada.GetJugador(), i, 1] > 0)
            {
                totalFichasAsignadas++;
            }
        }

        if (totalFichasAsignadas > 17)
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
            CambiaObjeto.QuitaMaterial(ficha);
            CambiaObjeto.PintaBlanco(ficha);
        }

        // Inicializamos el elemento seleccionado
        ElementoSeleccionado.SetElementoSeleccionado(0);
        // Limpiamos la selección de elemento
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Fuego"));
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Agua"));
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Madera"));

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
            CambiaObjeto.QuitaMaterial(ficha);
            CambiaObjeto.PintaGris(ficha);
        }

        // Inicializamos el elemento seleccionado
        ElementoSeleccionado.SetElementoSeleccionado(0);
        // Limpiamos la selección de elemento
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Fuego"));
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Agua"));
        CambiaObjeto.PintaBlanco(GameObject.FindGameObjectWithTag("Madera"));

    }

}
