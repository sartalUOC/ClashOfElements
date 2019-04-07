using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiaSeleccion : MonoBehaviour
{

    // Borra la selección de fichas de ambos jugadores sin cambiar las texturas de las fichas
    public void VolverMenu()
    {
        // Pone a 0 todos los valores de las fichas de los jugadores
        FichaSeleccionada.InicializaFichasJugador1();
        FichaSeleccionada.InicializaFichasJugador2();
        // Indica como desmarcadas todas las fichas y elementos
        FichaSeleccionada.InicializaFichasSeleccionadas();
        ElementoSeleccionado.SetElementoSeleccionado(0);
    }
    
    // Borra la selección de fichas y elementos del jugador 1
    public void BorraSeleccionJugador1()
    {
        GameObject[] fichas;

        // Pone a 0 todos los valores de las fichas del jugador 1
        FichaSeleccionada.InicializaFichasJugador1();
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
    public void BorraSeleccionJugador2()
    {
        GameObject[] fichas;

        // Pone a 0 todos los valores de las fichas del jugador 2
        FichaSeleccionada.InicializaFichasJugador2();
        // Indica como desmarcadas todas las fichas del jugador 2
        FichaSeleccionada.InicializaFichasSeleccionadas();

        // Añadimos al array todas las fichas del jugador 2
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
