using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numCasillaTablero : MonoBehaviour
{
    // Número de casilla
    public int idCasilla;
    // Fila de la casilla
    public int filaCasilla; // Valores posibles 1,2,3 -- izquierda, centro, derecha

    private int estaIluminada = 0; //0 o 1 o 2 - sin iluminar, en verde, en rojo
    private int estaOcupada = 0; // 0 o 1
    private int jugadorOcupa = -1; // 0 o 1 o -1 - Jugador 1, Jugador 2, o ninguno

    // Al marcar una casilla iluminada moveremos la ficha
    private void OnMouseUp()
    {
        if (this.GetEstaIluminada() == 1 && IniciaPartida.estaPausado == 0) { this.MueveFicha(); }
    }

    // Movemos la ficha y la su bandera si la lleva y actualizamos la información de las casillas origen y destino, y la información de la ficha
    private void MueveFicha()
    {
        GameObject bandera = null;
        GameObject[] fichas = null;
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
        }
        if (ControlTurno.GetTurnoJugador() == 1)
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
        }
        foreach (GameObject ficha in fichas)
        {
            if (ficha.GetComponent<MoverFicha>().GetSeleccionada() == 1)
            {
                // movemo la ficha
                ficha.transform.position = this.gameObject.transform.position;
                if (ficha.GetComponent<MoverFicha>().GetTieneBandera() == 1)
                {
                    if (ControlTurno.GetTurnoJugador() == 0)
                    {
                        bandera = GameObject.FindGameObjectWithTag("BanderaJugador1");
                    }
                    else
                    {
                        bandera = GameObject.FindGameObjectWithTag("BanderaJugador2");
                    }
                    // Movemos la bandera
                    bandera.transform.position = this.gameObject.transform.position;
                    bandera.GetComponent<MoverBandera>().SetCasillaBandera(this.GetIdCasilla());
                }

                GameObject[] casillas = null;
                casillas = GameObject.FindGameObjectsWithTag("Casilla");
                foreach (GameObject casilla in casillas)
                {
                    if (casilla.GetComponent<numCasillaTablero>().GetIdCasilla() == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        // Actualizamos información de la casilla origen
                        casilla.GetComponent<numCasillaTablero>().SetEstaOcupada(0);
                        casilla.GetComponent<numCasillaTablero>().SetJugadorOcupa(-1);
                    }
                }

                // Actualizamos información de las fichas
                ficha.GetComponent<MoverFicha>().SetCasillaFicha(this.GetIdCasilla());
                ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
                if (ControlTurno.GetTurnoJugador() == 1)
                {
                    ficha.GetComponent<MoverFicha>().PonerElementoNegro(ficha);
                }
                else
                {
                    CambiaObjeto.PintaBlanco(ficha);
                }
                // Actualizamos insformación de la casilla destino
                this.SetEstaOcupada(1);
                this.SetJugadorOcupa(ControlTurno.GetTurnoJugador());
            }
        }
        if (bandera != null && (bandera.GetComponent<MoverBandera>().GetCasillaBandera() < 4 || bandera.GetComponent<MoverBandera>().GetCasillaBandera() > 21))
        {
            // si al mover la ficha se lleva una ficha con la bandera al final del tablero contrario se gana la partida
            IniciaPartida.ActivarPanelVictoria();
        }
        else
        {
            // Tras mover la ficha se pasa el turno
            GameObject controlTurno;
            controlTurno = GameObject.Find("InfoJugador");
            controlTurno.GetComponent<ControlTurno>().CambioTurno();
        }
    }

    // Get idCasilla
    public int GetIdCasilla()
    {
        return this.idCasilla;
    }

    // Get está iluminada
    public int GetEstaIluminada()
    {
        return this.estaIluminada;
    }

    // Set está iluminada
    public void SetEstaIluminada(int valor)
    {
        this.estaIluminada = valor;
    }

    // Get fila casilla
    public int GetFilaCasilla()
    {
        return filaCasilla;
    }

    // Get está ocupada
    public int GetEstaOcupada()
    {
        return this.estaOcupada;
    }

    // Set está ocupada
    public void SetEstaOcupada(int valor)
    {
        this.estaOcupada = valor;
    }

    // Get jugador ocupa
    public int GetJugadorOcupa()
    {
        return this.jugadorOcupa;
    }

    // Set jugador ocupa
    public void SetJugadorOcupa(int valor)
    {
        this.jugadorOcupa = valor;
    }

}
