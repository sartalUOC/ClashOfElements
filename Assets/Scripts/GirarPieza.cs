using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirarPieza : MonoBehaviour
{
    // Gira la ficha seleccionada dependiendo del jugador y cambia el turno
    public void GirarPiezaSeleccionada()
    {
        GameObject[] fichas = null;

        // Sonido botón menú
        this.GetComponent<SonidoMenu>().SonidoSeleccionMenu();
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            foreach (GameObject ficha in fichas)
            {
                if (ficha.GetComponent<MoverFicha>().GetSeleccionada() == 1)
                {
                    ficha.GetComponent<MoverFicha>().CambiarCaraActiva();
                    ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha);
                    ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
                    // Sonido giro ficha
                    ficha.GetComponent<MoverFicha>().SonidoFicha(ficha.GetComponent<MoverFicha>().girarFicha);
                }
            }
        }
        else
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            foreach (GameObject ficha in fichas)
            {
                if (ficha.GetComponent<MoverFicha>().GetSeleccionada() == 1)
                {
                    ficha.GetComponent<MoverFicha>().CambiarCaraActiva();
                    ficha.GetComponent<MoverFicha>().PonerElementoNegro(ficha);
                    ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
                    // Sonido giro ficha
                    ficha.GetComponent<MoverFicha>().SonidoFicha(ficha.GetComponent<MoverFicha>().girarFicha);
                }
            }
        }
        GameObject controlTurno;
        controlTurno = GameObject.Find("InfoJugador");
        controlTurno.GetComponent<ControlTurno>().CambioTurno();
    }

}
