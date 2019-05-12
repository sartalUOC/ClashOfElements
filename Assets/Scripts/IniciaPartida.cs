using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaPartida : MonoBehaviour
{
    public static int estaPausado = 0;
    public static GameObject panelVictoria = null;

    // Al iniciar pone las fichas con los elementos correspondientes si ya se habían seleccionado
    void Start()
    {
        IniciaPartida.panelVictoria = GameObject.Find("Fondo");
        IniciaPartida.panelVictoria.SetActive(false);

        GameObject bandera = null;
        GameObject[] fichas = null;
        int[,,] datosFichas = new int[2, 9, 2];
        // Añadimos al array todas las fichas del jugador 1

        datosFichas = FichaSeleccionada.GetFichasJugadores();
        //for (int i = 0; i < 9; i++)
        //{
        //    datosFichas[0, i, 0] = Random.Range(1, 4);
        //    datosFichas[0, i, 1] = Random.Range(1, 4);
        //    datosFichas[1, i, 0] = Random.Range(1, 4);
        //    datosFichas[1, i, 1] = Random.Range(1, 4);
        //}
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

        // Añadimos al array todas las fichas del jugador 2
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
        
        ControlTurno.SetTurnoJugador(0);
        MoverFicha.DesactivarGiro();
    }

    void InicializaFicha(GameObject ficha, int[,,] datosFichas)
    {
        ficha.GetComponent<MoverFicha>().SetCaraActiva(FichaSeleccionada.GetCara());
        ficha.GetComponent<MoverFicha>().SetElemento0(datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, 0]);
        ficha.GetComponent<MoverFicha>().SetElemento1(datosFichas[ControlTurno.GetTurnoJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, 1]);
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            ficha.GetComponent<MoverFicha>().SetCasillaFicha(ficha.GetComponent<numFichaJugador>().idFicha);
            this.InicializarCasillas(ficha.GetComponent<numFichaJugador>().idFicha, ControlTurno.GetTurnoJugador());
        }
        else
        {
            ficha.GetComponent<MoverFicha>().SetCasillaFicha(25-ficha.GetComponent<numFichaJugador>().idFicha);
            this.InicializarCasillas(25-ficha.GetComponent<numFichaJugador>().idFicha, ControlTurno.GetTurnoJugador());
        }
        
        if (ficha.GetComponent<numFichaJugador>().idFicha == 5)
        {
            ficha.GetComponent<MoverFicha>().SetTieneBandera(1);
        }
        else
        {
            ficha.GetComponent<MoverFicha>().SetTieneBandera(0);
        }
    }

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
