using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaPartida : MonoBehaviour
{
    // Para controlar cuando se está mostrando el mensaje superpuesto de final e partida
    public static int estaPausado = 0;
    public static GameObject panelVictoria = null;
    public static GameObject panelSalir = null;

    // Al iniciar pone las fichas y banderas con los elementos correspondientes si ya se habían seleccionado
    void Start()
    {
        // Desactivamos el panel de victoria
        IniciaPartida.panelVictoria = GameObject.Find("Fondo");
        IniciaPartida.panelVictoria.SetActive(false);
        IniciaPartida.estaPausado = 0;

        // Desactivamos el panel de Salir
        IniciaPartida.panelSalir = GameObject.Find("FondoSalir");
        IniciaPartida.panelSalir.SetActive(false);

        GameObject bandera = null;
        GameObject[] fichas = null;
        int[,,] datosFichas = new int[2, 9, 2];
        // Añadimos al array todas las fichas y la bandera del jugador 1

        datosFichas = FichaSeleccionada.GetFichasJugadores();
        FichaSeleccionada.SetCara(0);
        ControlTurno.SetTurnoJugador(0);
        fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
        foreach (GameObject ficha in fichas)
        {
            // recorremos todas las fichas asignando el elemento y añadiendo a las fichas seleccionadas
            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 1)
            {
                CambiaObjeto.AsignaFuegoBlanco(ficha);
            }

            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 2)
            {
                CambiaObjeto.AsignaAguaBlanca(ficha);
            }

            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 3)
            {
                CambiaObjeto.AsignaMaderaBlanca(ficha);
            }
            this.InicializaFicha(ficha, datosFichas);
        }
        bandera = GameObject.FindGameObjectWithTag("BanderaJugador1");
        bandera.GetComponent<MoverBandera>().SetCasillaBandera(5);

        // Añadimos al array todas las fichas y la bandera del jugador 2
        ControlTurno.SetTurnoJugador(1);
        fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
        //datosFichas = FichaSeleccionada.GetFichasJugadores();
        foreach (GameObject ficha in fichas)
        {
            // recorremos todas las fichas asignando el elemento y añadiendo a las fichas seleccionadas
            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 1)
            {
                CambiaObjeto.AsignaFuegoNegro(ficha);
            }

            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 2)
            {
                CambiaObjeto.AsignaAguaNegra(ficha);
            }

            if (datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 3)
            {
                CambiaObjeto.AsignaMaderaNegra(ficha);
            }
            this.InicializaFicha(ficha, datosFichas);
        }
        bandera = GameObject.FindGameObjectWithTag("BanderaJugador2");
        bandera.GetComponent<MoverBandera>().SetCasillaBandera(20);
        
        // Preparamos el tueno y el botón de giro
        ControlTurno.SetTurnoJugador(0);
        MoverFicha.DesactivarGiro();
    }

    // Asignamos a la ficha los valores almacenados en el array durante la selección
    void InicializaFicha(GameObject ficha, int[,,] datosFichas)
    {
        // Inicializamos los datos de las fichas
        ficha.GetComponent<MoverFicha>().SetCaraActiva(FichaSeleccionada.GetCara());
        ficha.GetComponent<MoverFicha>().SetElemento0(datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, 0]);
        ficha.GetComponent<MoverFicha>().SetElemento1(datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, 1]);
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            // Inicializamos los datos de las casillas del jugador 1
            ficha.GetComponent<MoverFicha>().SetCasillaFicha(ficha.GetComponent<numFichaJugador>().idFicha);
            this.InicializarCasillas(ficha.GetComponent<numFichaJugador>().idFicha, ControlTurno.GetTurnoJugador());
        }
        else
        {
            // Inicializamos los datos de las casillas del jugador 2
            ficha.GetComponent<MoverFicha>().SetCasillaFicha(25-ficha.GetComponent<numFichaJugador>().idFicha);
            this.InicializarCasillas(25-ficha.GetComponent<numFichaJugador>().idFicha, ControlTurno.GetTurnoJugador());
        }
        
        // Indicamos qué fichas tiene la bandera
        if (ficha.GetComponent<numFichaJugador>().idFicha == 5)
        {
            ficha.GetComponent<MoverFicha>().SetTieneBandera(1);
        }
        else
        {
            ficha.GetComponent<MoverFicha>().SetTieneBandera(0);
        }
    }


    // Inicializar los datos de las casillas referidos a si está ocupada y de qué jugador es la ficha que la ocupa
    void InicializarCasillas(int numCasilla,int jugador)
    {
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            if (numCasilla == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
            {
                casilla.GetComponent<numCasillaTablero>().SetEstaOcupada(1);
                casilla.GetComponent<numCasillaTablero>().SetJugadorOcupa(jugador);
            }
        }
    }

    // Activar panel de victoria
    public static void ActivarPanelVictoria()
    {
        IniciaPartida.panelVictoria.SetActive(true);
        IniciaPartida.estaPausado = 1;
    }
}
