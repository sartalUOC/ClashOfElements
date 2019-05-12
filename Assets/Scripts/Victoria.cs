using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoria : MonoBehaviour
{
    public Text textoVictoria;

    private void Update()
    {
        textoVictoria.text = "Victoria del Juagador ";
        textoVictoria.text += ControlTurno.GetTurnoJugador()+1;
    }

}
