using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirarPieza : MonoBehaviour
{

    public void GirarPiezaSeleccionada()
    {
        GameObject[] fichas = null;

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
                }
            }
        }
        GameObject controlTurno;
        controlTurno = GameObject.Find("InfoJugador");
        controlTurno.GetComponent<ControlTurno>().CambioTurno();
    }

}
