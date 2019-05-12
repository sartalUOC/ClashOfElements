using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    public Text marcador;

    private void Start()
    {
        this.marcador.text = "0";
    }

    public void IncrementaMarcador()
    {
        int fichasTomadas;
        fichasTomadas = int.Parse(marcador.text);
        fichasTomadas++;
        this.marcador.text = fichasTomadas.ToString();
    }

}
