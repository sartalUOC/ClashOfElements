using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiaSeleccion : MonoBehaviour
{

    // Borra la selección de fichas de ambos jugadores sin cambiar las texturas de las fichas
    public void VolverMenu()
    {
        // Pone a 0 todos los valores de las fichas de los jugadores
        FichaSeleccionada.SetCara(0);
        FichaSeleccionada.InicializaFichasJugador1();
        FichaSeleccionada.InicializaFichasJugador2();
        FichaSeleccionada.SetCara(1);
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

        // Sonido botón menú
        this.GetComponent<SonidoMenu>().SonidoSeleccionMenu();
        // Pone a 0 los valores de las fichas del jugador 1 de la cara actual
        FichaSeleccionada.InicializaFichasJugador1();
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
    public void BorraSeleccionJugador2()
    {
        GameObject[] fichas;

        // Sonido botón menú
        this.GetComponent<SonidoMenu>().SonidoSeleccionMenu();
        // Pone a 0 los valores de las fichas del jugador 2 de la cara acual
        FichaSeleccionada.InicializaFichasJugador2();
        // Indica como desmarcadas todas las fichas del jugador 2
        FichaSeleccionada.InicializaFichasSeleccionadas();

        // Añadimos al array todas las fichas del jugador 2
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

    // Borramos las asignaciones del jugador 1
    public void CancelarJugador1()
    {
        // Pone a 0 todos los valores de las fichas de los jugadores
        FichaSeleccionada.SetCara(0);
        FichaSeleccionada.InicializaFichasJugador1();
        FichaSeleccionada.SetCara(1);
        FichaSeleccionada.InicializaFichasJugador1();
        // Indica como desmarcadas todas las fichas y elementos
        FichaSeleccionada.InicializaFichasSeleccionadas();
        ElementoSeleccionado.SetElementoSeleccionado(0);
    }

    // Borramos las asignaciones del jugador 2
    public void CancelarJugador2()
    {
        // Pone a 0 todos los valores de las fichas de los jugadores
        FichaSeleccionada.SetCara(0);
        FichaSeleccionada.InicializaFichasJugador2();
        FichaSeleccionada.SetCara(1);
        FichaSeleccionada.InicializaFichasJugador2();
        // Indica como desmarcadas todas las fichas y elementos
        FichaSeleccionada.InicializaFichasSeleccionadas();
        ElementoSeleccionado.SetElementoSeleccionado(0);
    }

}
