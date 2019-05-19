using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverFicha : MonoBehaviour
{

    // Cara activa
    private int caraActiva; // 0 o 1
    // Elemento Cara 0
    private int elemento0;
    // Elemento Cara 1
    private int elemento1;
    // ficha seleccionada
    private int seleccionada = 0; // 0 o 1, no seleccionada / seleccionada
    // Tiene Bandera
    private int tieneBandera; // 0 o 1, no seleccionada / seleccionada
    // Casilla en la que se ubica la ficha
    private int casillaFicha;
    // Sonidos
    public AudioClip girarFicha;
    public AudioClip moverBandera;
    public AudioClip moverFicha;
    public AudioClip movimientoIncorrecto;
    public AudioClip tomarFicha;
    public AudioClip seleccionFicha;

    AudioSource audioSource;

    // Inicializar audio source
    private void Start()
    {
        // Inicializamos el audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Al seleccionar una ficha controlamos tres posibilidades, pintamos los posibles destinos de su movimiento, le pasamos la bandera, o la vamos a tomar
    private void OnMouseUp()
    {
        if (IniciaPartida.estaPausado == 0)
        {
            if ((ControlTurno.GetTurnoJugador() == 0 && this.tag == "FichasJugador1") || (ControlTurno.GetTurnoJugador() == 1 && this.tag == "FichasJugador2"))
            {
                GameObject bandera = null;
                if (ControlTurno.GetTurnoJugador() == 0) { bandera = GameObject.FindGameObjectWithTag("BanderaJugador1"); }
                if (ControlTurno.GetTurnoJugador() == 1) { bandera = GameObject.FindGameObjectWithTag("BanderaJugador2"); }
                if (this.GetSeleccionada() == 1 && bandera.GetComponent<MoverBandera>().GetSeleccionada() == 1)
                {
                    // Movemos la bandera
                    this.MueveBandera(bandera);
                }
                else
                {
                    // Sonido movimiento bandera
                    this.GetComponent<MoverFicha>().SonidoFicha(seleccionFicha);

                    // Marcamnos los posibles destinos
                    this.MarcaFicha();
                }
            }
            if (((ControlTurno.GetTurnoJugador() == 0 && this.tag == "FichasJugador2") || (ControlTurno.GetTurnoJugador() == 1 && this.tag == "FichasJugador1")) && (this.GetComponent<MoverFicha>().GetTieneBandera() == 0))
            {
                // Tomamos la ficha
                this.TomarFicha();
            }
        }
    }

    // Movemos la bandera a la ficha destino
    void MueveBandera(GameObject bandera)
    {
        GameObject[] fichas = null;
        if (ControlTurno.GetTurnoJugador() == 0) { fichas = GameObject.FindGameObjectsWithTag("FichasJugador1"); }
        if (ControlTurno.GetTurnoJugador() == 1) { fichas = GameObject.FindGameObjectsWithTag("FichasJugador2"); }
        foreach (GameObject ficha in fichas)
        {
            if (ficha.GetComponent<MoverFicha>().GetTieneBandera() == 1) { ficha.GetComponent<MoverFicha>().SetTieneBandera(0); }
            if (ControlTurno.GetTurnoJugador() == 0) { ficha.GetComponent<MoverFicha>().PonerElementoBlanco(ficha); }
            if (ControlTurno.GetTurnoJugador() == 1) { ficha.GetComponent<MoverFicha>().PonerElementoNegro(ficha); }
        }

        bandera.transform.position = this.transform.position;
        bandera.GetComponent<MoverBandera>().SetSeleccionada(0);
        bandera.GetComponent<MoverBandera>().SetCasillaBandera(this.GetCasillaFicha());
        this.SetTieneBandera(1);

        if (bandera.GetComponent<MoverBandera>().GetCasillaBandera() <4 || bandera.GetComponent<MoverBandera>().GetCasillaBandera()>21)
        {
            // Control de victoria si la bandera se ha movido a la última línea del jugador contrario
            IniciaPartida.ActivarPanelVictoria();
        }
        else
        {
            // Tras mover la bandera se pasa el turno
            GameObject controlTurno;
            controlTurno = GameObject.Find("InfoJugador");
            controlTurno.GetComponent<ControlTurno>().CambioTurno();

            // Sonido movimiento bandera
            this.GetComponent<MoverFicha>().SonidoFicha(moverBandera);
        }

    }

    // Tomar una ficha del otro jugador
    void TomarFicha()
    {
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            // Solo si la casilla está marcada indicando que la pieza que tiene pieza es posible tomarla
            if (this.GetCasillaFicha() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() && casilla.GetComponent<numCasillaTablero>().GetEstaIluminada() == 2)
            {
                GameObject[] fichas = null;
                GameObject marcador = null;
                if (ControlTurno.GetTurnoJugador() == 0)
                {
                    fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
                    marcador = GameObject.Find("Marcador Jugador 1");                    
                }
                if (ControlTurno.GetTurnoJugador() == 1)
                {
                    fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
                    marcador = GameObject.Find("Marcador Jugador 2");
                }
                foreach (GameObject ficha in fichas)
                {
                    // Si la ficha no tiene la bandera y puedo tomar la ficha, realizamos los movimientos de fichas
                    if (ficha.GetComponent<MoverFicha>().GetSeleccionada() == 1 && ficha.GetComponent<MoverFicha>().GetTieneBandera() == 0 && this.PuedoTomar(ficha, this.gameObject) == 1)
                    {
                        ficha.transform.position = this.gameObject.transform.position;

                        GameObject[] casillasOrigen = null;
                        casillasOrigen = GameObject.FindGameObjectsWithTag("Casilla");
                        foreach (GameObject casillaOrigen in casillasOrigen)
                        {
                            if (casillaOrigen.GetComponent<numCasillaTablero>().GetIdCasilla() == ficha.GetComponent<MoverFicha>().GetCasillaFicha())
                            {
                                casillaOrigen.GetComponent<numCasillaTablero>().SetEstaOcupada(0);
                                casillaOrigen.GetComponent<numCasillaTablero>().SetJugadorOcupa(-1);
                            }
                        }

                        ficha.GetComponent<MoverFicha>().SetCasillaFicha(this.GetCasillaFicha());
                        ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
                        if (ControlTurno.GetTurnoJugador() == 1)
                        {
                            ficha.GetComponent<MoverFicha>().PonerElementoNegro(ficha);
                        }
                        else
                        {
                            CambiaObjeto.PintaBlanco(ficha);
                        }
                        casilla.GetComponent<numCasillaTablero>().SetEstaOcupada(1);
                        casilla.GetComponent<numCasillaTablero>().SetJugadorOcupa(ControlTurno.GetTurnoJugador());

                        // Sonido tomar ficha
                        this.GetComponent<MoverFicha>().SonidoFicha(tomarFicha);

                        // Tras tomar la ficha cambiamos el turno y destruimos la ficha tomada
                        GameObject controlTurno;
                        controlTurno = GameObject.Find("InfoJugador");
                        controlTurno.GetComponent<ControlTurno>().CambioTurno();

                        StartCoroutine(DestruirFicha(marcador));
                    }
                }
            }
            if (this.GetCasillaFicha() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() && casilla.GetComponent<numCasillaTablero>().GetEstaIluminada() != 2)
            {
                // Sonido movimiento incorrecto
                this.GetComponent<MoverFicha>().SonidoFicha(movimientoIncorrecto);
            }
        }
    }

    // Pausa previa a la destrucción de la ficha para que pueda haber sonido
    IEnumerator DestruirFicha(GameObject marcador)
    {
        yield return new WaitForSeconds(0.1f);
        Object.Destroy(this.gameObject);
        marcador.GetComponent<Marcador>().IncrementaMarcador();
    }
    // comprobamos que una ficha puede comer a otra
    int PuedoTomar(GameObject fichaToma, GameObject fichaTomada)
    {
        int elementoTomado = fichaTomada.GetComponent<MoverFicha>().GetElementoActivo();
        int elementoToma = fichaToma.GetComponent<MoverFicha>().GetElementoActivo();

        if (fichaToma.GetComponent<MoverFicha>().GetTieneBandera() == 0 && fichaTomada.GetComponent<MoverFicha>().GetTieneBandera() == 0)
        {
            if (elementoToma == 1 && elementoTomado == 3)
            {
                return 1;
            }
            if (elementoToma == 2 && elementoTomado == 1)
            {
                return 1;
            }
            if (elementoToma == 3 && elementoTomado == 2)
            {
                return 1;
            }
        }

        return 0;
    }

    // Seleccionamos una ficha e indicamos sus posibles destinos
    void MarcaFicha()
    {
        GameObject[] fichas = null;
        GameObject bandera = null;

        // Desmarcamos todas las fichas y marcmos la seleccionada
        if (ControlTurno.GetTurnoJugador() == 0 && this.tag == "FichasJugador1")
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            foreach (GameObject ficha in fichas)
            {
                this.PonerElementoBlanco(ficha);
                ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
            }
            // Deseleccionamos la bandera por si estaba seleccionada previamente
            bandera = GameObject.FindGameObjectWithTag("BanderaJugador1");
            bandera.GetComponent<MoverBandera>().SetSeleccionada(0);
            this.SeleccionFicha();
        }

        // Desmarcamos todas las fichas y marcmos la seleccionada
        if (ControlTurno.GetTurnoJugador() == 1 && this.tag == "FichasJugador2")
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            foreach (GameObject ficha in fichas)
            {
                this.PonerElementoNegro(ficha);
                ficha.GetComponent<MoverFicha>().SetSeleccionada(0);
            }
            // Deseleccionamos la bandera por si estaba seleccionada previamente
            bandera = GameObject.FindGameObjectWithTag("BanderaJugador2");
            bandera.GetComponent<MoverBandera>().SetSeleccionada(0);
            this.PonerElementoBlanco(this.gameObject);
            this.SeleccionFicha();
        }

    }

    // Al seleccionar una ficha, la iluminamos en verde, activamos el giro y pintamos las casillas donde se puede mover
    private void SeleccionFicha()
    {
        CambiaObjeto.PintaVerde(this.gameObject);
        this.SetSeleccionada(1);
        MoverFicha.ActivarGiro();
        if (this.GetTieneBandera() == 1)
        {
            // si la ficha seleccionada tiene la bandera se marcará solo la casilla frente a la ficha si está libre
            this.IluminarCasillasFichaBandera();
        }
        else
        {
            // si la ficha no tiene la bandera marcaremos los posibles destinos de la ficha distinguiendo si es solo moviemiento o si puede comer
            this.IluminarCasillas();
        }
    }


    // Indicamos las casillas a las que la ficha con la bandera se puede mover
    private void IluminarCasillasFichaBandera()
    {
        MoverFicha.DesmarcarCasillas();
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            if ((this.GetCasillaFicha() + 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() && ControlTurno.GetTurnoJugador() == 0) ||
                (this.GetCasillaFicha() - 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() && ControlTurno.GetTurnoJugador() == 1))
            {
                if (casilla.GetComponent<numCasillaTablero>().GetEstaOcupada() == 0)
                {
                    CambiaObjeto.PintaVerde(casilla);
                    casilla.GetComponent<numCasillaTablero>().SetEstaIluminada(1);
                }
            }
        }
    }

    // Recorremos las casillas a pintar según el jugador y la ficha en la que está la ficha
    private void IluminarCasillas()
    {
        MoverFicha.DesmarcarCasillas();
        int fila=0;
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            if (this.GetCasillaFicha() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
            {
                fila = casilla.GetComponent<numCasillaTablero>().GetFilaCasilla();
            }            
        }

        if (fila == 1 && ControlTurno.GetTurnoJugador() == 0)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() + 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() || 
                    this.GetCasillaFicha() + 4 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() || 
                    this.GetCasillaFicha() + 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }
        if (fila == 2 && ControlTurno.GetTurnoJugador() == 0)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() - 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 2 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 4 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }
        if (fila == 3 && ControlTurno.GetTurnoJugador() == 0)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() - 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 2 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }

        if (fila == 1 && ControlTurno.GetTurnoJugador() == 1)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() - 2 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }
        if (fila == 2 && ControlTurno.GetTurnoJugador() == 1)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() - 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() + 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 2 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 4 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }
        if (fila == 3 && ControlTurno.GetTurnoJugador() == 1)
        {
            foreach (GameObject casilla in casillas)
            {
                if (this.GetCasillaFicha() - 1 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 4 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla() ||
                    this.GetCasillaFicha() - 3 == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    this.PintaCasilla(casilla);
                }
            }
        }
    }

    // dependiendo de si la casilla destino está ocupada o no, y qué ficha la ocupa, pintaremos de verde o rojo la casilla
    void PintaCasilla(GameObject casilla)
    {
        if (casilla.GetComponent<numCasillaTablero>().GetEstaOcupada() == 0)
        {
            CambiaObjeto.PintaVerde(casilla);
            casilla.GetComponent<numCasillaTablero>().SetEstaIluminada(1);
        }
        if (casilla.GetComponent<numCasillaTablero>().GetEstaOcupada() == 1 && casilla.GetComponent<numCasillaTablero>().GetJugadorOcupa() == 0 && ControlTurno.GetTurnoJugador() == 1)
        {
            GameObject[] fichas = null;
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            foreach (GameObject ficha in fichas)
            {
                if (PuedoTomar(this.gameObject, ficha) == 1 && ficha.GetComponent<MoverFicha>().GetCasillaFicha() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    CambiaObjeto.PintaRojo(casilla);
                    casilla.GetComponent<numCasillaTablero>().SetEstaIluminada(2);
                }
            }
        }
        if (casilla.GetComponent<numCasillaTablero>().GetEstaOcupada() == 1 && casilla.GetComponent<numCasillaTablero>().GetJugadorOcupa() == 1 && ControlTurno.GetTurnoJugador() == 0)
        {
            GameObject[] fichas = null;
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            foreach (GameObject ficha in fichas)
            {
                if (PuedoTomar(this.gameObject, ficha) == 1 && ficha.GetComponent<MoverFicha>().GetCasillaFicha() == casilla.GetComponent<numCasillaTablero>().GetIdCasilla())
                {
                    CambiaObjeto.PintaRojo(casilla);
                    casilla.GetComponent<numCasillaTablero>().SetEstaIluminada(2);
                }
            }
        }
    }

    // Cambiar Cara Activa
    public void CambiarCaraActiva()
    {
        if (this.GetCaraActiva() == 0)
        {
            this.SetCaraActiva(1);
        }
        else
        {
            this.SetCaraActiva(0);
        }
        this.MarcaFicha();
    }

    // Set cara Activa
    public void SetCaraActiva(int cara)
    {
        this.caraActiva = cara;
    }

    // Get cara activa
    public int GetCaraActiva()
    {
        return this.caraActiva;
    }

    // Get elemento de la cara activa
    public int GetElementoActivo() {
        if (this.GetCaraActiva() == 0)
        {
            return this.elemento0;
        }
        else
        {
            return this.elemento1;
        }
    }

    // Set Elemento cara 0
    public void SetElemento0(int elemento)
    {
        this.elemento0 = elemento;
    }

    // Get Elemento cara 0
    public int GetElemento0()
    {
        return this.elemento0;
    }

    // Set Elemento cara 1
    public void SetElemento1(int elemento)
    {
        this.elemento1 = elemento;
    }

    // Get Elemento cara 1
    public int GetElemento1()
    {
        return this.elemento1;
    }

    // Get Seleccionada
    public int GetSeleccionada()
    {
        return this.seleccionada;
    }

    // Set Seleccionado
    public void SetSeleccionada(int valor)
    {
        this.seleccionada = valor;
    }

    // Get tiene bandera
    public int GetTieneBandera()
    {
        return this.tieneBandera;
    }

    // Set tiene bandera
    public void SetTieneBandera(int valor)
    {
        this.tieneBandera = valor;
    }

    // Get Casilla Ficha
    public int GetCasillaFicha()
    {
        return this.casillaFicha;
    }

    // Set Casilla Ficha
    public void SetCasillaFicha(int numCasilla)
    {
        this.casillaFicha = numCasilla;
    }

    // Poner elemento blanco en ficha
    public void PonerElementoBlanco(GameObject ficha)
    {
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 1)
        {
            CambiaObjeto.AsignaFuegoBlanco(ficha);
        }
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 2)
        {
            CambiaObjeto.AsignaAguaBlanca(ficha);
        }
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 3)
        {
            CambiaObjeto.AsignaMaderaBlanca(ficha);
        }
    }

    // Poner elemento negro en ficha
    public void PonerElementoNegro(GameObject ficha)
    {
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 1)
        {
            CambiaObjeto.AsignaFuegoNegro(ficha);
        }
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 2)
        {
            CambiaObjeto.AsignaAguaNegra(ficha);
        }
        if (ficha.GetComponent<MoverFicha>().GetElementoActivo() == 3)
        {
            CambiaObjeto.AsignaMaderaNegra(ficha);
        }
    }

    //
    // Activar y desactivar botones en base a la ficha seleccionada
    //

    public static void ActivarGiro()
    {
        GameObject boton = null;
        boton = GameObject.FindGameObjectWithTag("Girar");
        boton.GetComponent<Button>().interactable = true;
    }

    public static void DesactivarGiro()
    {
        GameObject boton = null;
        boton = GameObject.FindGameObjectWithTag("Girar");
        boton.GetComponent<Button>().interactable = false;
    }

    //
    // Desmarcar las casillas activadas 
    //

    public static void DesmarcarCasillas()
    {
        GameObject[] casillas = null;
        casillas = GameObject.FindGameObjectsWithTag("Casilla");
        foreach (GameObject casilla in casillas)
        {
            CambiaObjeto.PintaBlanco(casilla);
            casilla.GetComponent<numCasillaTablero>().SetEstaIluminada(0);
        }
    }

    // Activar sonido
    public void SonidoFicha(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

}
