using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBandera : MonoBehaviour
{

    // Guarda si la bandera está seleccionada
    private int seleccionada = 0; // 0 o 1, no seleccionada / seleccionada
    // Casilla en la que está la bandera
    private int casillaBandera;
    // Sonido selección bandera
    public AudioClip seleccionBandera;

    AudioSource audioSource;

    // Inicializar audio source
    private void Start()
    {
        // Inicializamos el audio source
        audioSource = GetComponent<AudioSource>();
    }

    // al seleccionar la bandera, se selecciona y se iluminan las fichas correspondientes
    private void OnMouseUp()
    {
        if (IniciaPartida.estaPausado == 0 && (ControlTurno.GetTurnoJugador() == 0 && this.tag == "BanderaJugador1") || (ControlTurno.GetTurnoJugador() == 1 && this.tag == "BanderaJugador2"))
        {
            // Sonido selección bandera
            this.SonidoSeleccionBandera();

            this.MarcaBandera();
            this.IluminarFichas();
        }
    }

    // Selección de la bandera
    private void MarcaBandera()
    {
        // Marcamos y pintamos la ficha como seleccionada
        this.SetSeleccionada(1);

        MoverFicha.DesactivarGiro();
        MoverFicha.DesmarcarCasillas(); // Para desmarcar las casillas que hubieran podido estar marcadas por una selección previa


        //Desmarcamos la fichas que pudieran haberse seleccionado previamente
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
                if (ControlTurno.GetTurnoJugador() == 0) { ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha); }
                if (ControlTurno.GetTurnoJugador() == 1) { ficha.GetComponent<MoverFicha>().PonerElementoNegro(ficha); }
                ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
            }
        }
    }

    // Iluminamos las fichas a las que podemos pasar la bandera
    private void IluminarFichas()
    {
        int fila = 0;
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            if (this.GetCasillaBandera() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
            {
                fila = casilla.GetComponent<numCasillaTablero>().GetFilaCasilla();
            }
        }

        if (ControlTurno.GetTurnoJugador() == 0)
        {
            GameObject[] fichas = null;
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            foreach (GameObject ficha in fichas)
            {
                if (fila == 1)
                {
                    if (this.GetCasillaBandera() + 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 4 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
                if (fila == 2)
                {
                    if (this.GetCasillaBandera() - 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 2 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 4 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
                if (fila == 3)
                {
                    if (this.GetCasillaBandera() - 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 2 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
            }    
        }

        if (ControlTurno.GetTurnoJugador() == 1)
        {
            GameObject[] fichas = null;
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            foreach (GameObject ficha in fichas)
            {
                if (fila == 1)
                {
                    if (this.GetCasillaBandera() + 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 2 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha);
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
                if (fila == 2)
                {
                    if (this.GetCasillaBandera() - 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() + 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 2 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 4 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha);
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
                if (fila == 3)
                {
                    if (this.GetCasillaBandera() - 3 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 4 == ficha.GetComponent<MoverFicha>().GetCasillaFicha() ||
                        this.GetCasillaBandera() - 1 == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                    {
                        ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha);
                        CambiaObjeto.PintaVerde(ficha);
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(1);
                    }
                }
            }
        }

    }

    // Set Seleccionado
    public void SetSeleccionada(int valor)
    {
        this.seleccionada = valor;
        if (valor == 1)
        {
            CambiaObjeto.PintaVerde(this.gameObject);
        }
        if (valor == 0 && ControlTurno.GetTurnoJugador() == 0)
        {
            CambiaObjeto.PintaNegro(this.gameObject);
        }
        if (valor == 0 && ControlTurno.GetTurnoJugador() == 1)
        {
            CambiaObjeto.PintaBlanco(this.gameObject);
        }
    }

    // Get Seleccionada
    public int GetSeleccionada()
    {
        return this.seleccionada;
    }

    // Get Casilla Bandera
    public int GetCasillaBandera()
    {
        return this.casillaBandera;
    }

    // Set Casilla Bandera
    public void SetCasillaBandera(int numCasilla)
    {
        this.casillaBandera= numCasilla;
    }

    // Activar sonido
    public void SonidoSeleccionBandera()
    {
        audioSource.PlayOneShot(seleccionBandera);
    }
}
