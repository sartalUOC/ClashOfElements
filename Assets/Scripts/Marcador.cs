using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    // Texto para indicar la fichas comidas por cada jugador
    public Text marcador;

    private void Start()
    {
        // Inicializamos a 0
        this.marcador.text = "0";
    }

    // Cada vez que in jugador come una ficha se incremeta el valor del contador
    public void IncrementaMarcador()
    {
        int fichasTomadas;
        fichasTomadas = int.Parse(marcador.text);
        fichasTomadas++;
        this.marcador.text = fichasTomadas.ToString();
    }

}
