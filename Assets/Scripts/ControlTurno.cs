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

    // Start is called before the first frame update
    void Start()
    {
        this.SetTurnotexto("Turno Jugador 1");
    }

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

    public void CambioTurno()
    {
        MoverFicha.DesactivarGiro();
        MoverFicha.DesmarcarCasillas();
        StartCoroutine(Pausa());        
    }

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
