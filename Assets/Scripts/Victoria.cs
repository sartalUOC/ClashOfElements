using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoria : MonoBehaviour
{
    // texto donde indicaremos el jugador que ha ganao
    public Text textoVictoria;

    // Actualizamos el texto del vencedor en base al tugador que tenía el turno al darse la condición de victoria
    private void Update()
    {
        textoVictoria.text = "Victoria del Juagador ";
        textoVictoria.text += ControlTurno.GetTurnoJugador()+1;
    }

}
