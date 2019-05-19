using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTurno : MonoBehaviour
{
    // Texto superior del canvas
    public Text turnoTexto;
    // Jugador al que le toca el turno
    static protected int turnoJugador; // 0 o 1

    // Iniciamos con el tueno del jugador 1
    void Start()
    {
        this.SetTurnotexto("Turno Jugador 1");
    }

    // Actualizamos el texto del canvas según el jugador que tiene el turno
    void Update()
    {
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            this.SetTurnotexto("Turno Jugador 1");
        }
        else
        {
            this.SetTurnotexto("Turno Jugador 2");
        }
    }

    // Cambiamos el turno del jugador
    public void CambioTurno()
    {
        MoverFicha.DesactivarGiro();
        MoverFicha.DesmarcarCasillas();
        StartCoroutine(Pausa());        
    }

    // Para que el jugador vea los efectos de su movimiento antes del cambio de cámara
    // hacemos una pausa y movemos la cámara
    IEnumerator Pausa()
    {
        Quaternion rotacion;

        yield return new WaitForSeconds(0.4f);
        
        if (ControlTurno.GetTurnoJugador() == 0)
        {
            ControlTurno.SetTurnoJugador(1);
            rotacion = Quaternion.Euler(130, 0, 180);
            GameObject.Find("Main Camera").transform.position = new Vector3(0, 7, 7);
            GameObject.Find("Main Camera").transform.rotation = rotacion;
        }
        else
        {
            ControlTurno.SetTurnoJugador(0);
            rotacion = Quaternion.Euler(50, 0, 0);
            GameObject.Find("Main Camera").transform.position = new Vector3(0, 7, -6);
            GameObject.Find("Main Camera").transform.rotation = rotacion;
        }
    }


    // Set turnotexto
    public void SetTurnotexto(string Texto)
    {
        this.turnoTexto.text = Texto;
    }

    // Set TurnoJugador
    public static void SetTurnoJugador(int jugador)
    {
        ControlTurno.turnoJugador = jugador;
    }

    // Get TurnoJugador
    public static int GetTurnoJugador()
    {
        return ControlTurno.turnoJugador;
    }
}
