using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FichaSeleccionada : MonoBehaviour
{
    // Para guardar que fichas ya se han seleccionado
    static protected int[] fichasSeleccionadas = new int[9];
    static protected int totalFichasSeleccionadas = 0;
    // Guarda la posición y elemento de cada ficha
    static protected int[,,] fichasJugadores = new int[2, 9, 2]; //jugador, elemento y cara
    // Cara que estamos seleccionando
    static protected int cara; // 0 o 1
    // Jugador que está seleccionando fichas
    static protected int jugador; // 0 o 1

    // Comportamiento al pinchar
    private void OnMouseUp()
    {
        this.GetComponent<numFichaJugador>().SonidoSeleccion();
        // Si no hay elemento seleccionado permitiremos ir seleccionando o deseleccinando varias fichas del jugador1
        if (ElementoSeleccionado.GetElementoSeleccionado() == 0)
        {
            // Si la ficha no estaba seleccionada la marcamos de verde, si ya estaba seleccionada la ponemos blanca
            if (fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] == 0)
            {
                if (FichaSeleccionada.GetJugador() == 1 && FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(),this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] >0)
                {
                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 1)
                    {
                        CambiaObjeto.AsignaFuegoBlanco(this.gameObject);
                    }

                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 2)
                    {
                        CambiaObjeto.AsignaAguaBlanca(this.gameObject);
                    }

                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 3)
                    {
                        CambiaObjeto.AsignaMaderaBlanca(this.gameObject);
                    }
                }

                CambiaObjeto.PintaVerde(this.gameObject);
                fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] = 1;
                totalFichasSeleccionadas++;
            }
            else
            {
                if (FichaSeleccionada.GetJugador() == 0)
                {
                    CambiaObjeto.PintaBlanco(this.gameObject);
                }
                if (FichaSeleccionada.GetJugador() == 1 && FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.cara] == 0)
                {
                    CambiaObjeto.PintaGris(this.gameObject);
                }
                if (FichaSeleccionada.GetJugador() == 1 && FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.cara] > 0)
                {
                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 1)
                    {
                        CambiaObjeto.AsignaFuegoNegro(this.gameObject);
                    }

                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 2)
                    {
                        CambiaObjeto.AsignaAguaNegra(this.gameObject);
                    }

                    if (FichaSeleccionada.fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] == 3)
                    {
                        CambiaObjeto.AsignaMaderaNegra(this.gameObject);
                    }
                }

                fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] = 0;
                totalFichasSeleccionadas--;
            }

        }
        else
        // Si hay un elemento seleccionado, cambiaremos el material de la ficha
        {
            // Si la ficha ya tiene ese elemento se lo quitaremos
            if (ElementoSeleccionado.GetElementoSeleccionado() == fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()])
            {
                CambiaObjeto.QuitaMaterial(this.gameObject);
                fichasJugadores[FichaSeleccionada.GetJugador(), this.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] = 0;
            }
            else // Si la ficha no tiene ese elemento, le asignaremos el elemento seleccionado independientemente del elemento que tuviera la ficha anteriormente
            {
                if (FichaSeleccionada.GetJugador() == 0)
                {
                    if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                    {
                        CambiaObjeto.AsignaFuegoBlanco(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                    {
                        CambiaObjeto.AsignaAguaBlanca(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                    {
                        CambiaObjeto.AsignaMaderaBlanca(this.gameObject);
                    }
                }
                if (FichaSeleccionada.GetJugador() == 1)
                {
                    if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                    {
                        CambiaObjeto.AsignaFuegoNegro(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                    {
                        CambiaObjeto.AsignaAguaNegra(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                    {
                        CambiaObjeto.AsignaMaderaNegra(this.gameObject);
                    }
                }
                FichaSeleccionada.SetFichaJugador(this.gameObject);
            }
        }
    }

    // devuelve las fichas que están seleccionadas
    public static int[] GetFichasSeleccionadas()
    {
        return fichasSeleccionadas;
    }

    // devuelve el número total de fichas seleccionadas
    public static int GetTotalFichasSeleccionadas()
    {
        return totalFichasSeleccionadas;
    }

    // devuelve las fichas de los jugadores
    public static int[,,] GetFichasJugadores()
    {
        return fichasJugadores;
    }

    // Guarda los datos de una ficha para el jugador
    public static void SetFichaJugador(GameObject obj)
    {
        fichasJugadores[FichaSeleccionada.GetJugador(),obj.GetComponent<numFichaJugador>().idFicha - 1, FichaSeleccionada.GetCara()] = ElementoSeleccionado.GetElementoSeleccionado();
    }

    // Inicializa las posiciones y elementos de las fichas del jugador 1
    public static void InicializaFichasJugador1()
    {
        for (int i = 0; i < 9; i++)
        {
            fichasJugadores[0,i, FichaSeleccionada.cara] = 0;
        }
    }

    // Inicializa las posiciones y elementos de las fichas del jugador 2
    public static void InicializaFichasJugador2()
    {
        for (int i = 0; i < 9; i++)
        {
            fichasJugadores[1,i, FichaSeleccionada.cara] = 0;
        }
    }

    // Inicializa las fichas seleccionadas
    public static void InicializaFichasSeleccionadas()
    {
        for (int i = 0; i < 9; i++)
        {
            fichasSeleccionadas[i] = 0;
        }
        totalFichasSeleccionadas = 0;
    }

    // Set cara
    public static void SetCara(int cara)
    {
        FichaSeleccionada.cara = cara;
    }

    // Get cara
    public static int GetCara()
    {
        return FichaSeleccionada.cara;
    }

    // Set jugador
    public static void SetJugador(int jugador)
    {
        FichaSeleccionada.jugador = jugador;
    }

    // Get jugador
    public static int GetJugador()
    {
        return FichaSeleccionada.jugador;
    }

}
