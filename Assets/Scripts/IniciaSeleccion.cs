using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaSeleccion : MonoBehaviour
{
    // Al iniciar pone las fichas con los elementos correspondientes si ya se habían seleccionado
    void Start()
    {
        GameObject[] fichas = null;
        int[,,] datosFichas = null;
        // Añadimos al array todas las fichas del jugador 1
        if (FichaSeleccionada.GetJugador() == 0)
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            datosFichas = FichaSeleccionada.GetFichasJugadores();
            foreach (GameObject ficha in fichas)
            {
                // recorremos todas las fichas asignando el elemento y añadiendo a las fichas seleccionadas
                if (datosFichas[FichaSeleccionada.GetJugador(),(ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 1)
                {
                    CambiaObjeto.AsignaFuegoBlanco(ficha);
                }

                if (datosFichas[FichaSeleccionada.GetJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 2)
                {
                    CambiaObjeto.AsignaAguaBlanca(ficha);
                }

                if (datosFichas[FichaSeleccionada.GetJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 3)
                {
                    CambiaObjeto.AsignaMaderaBlanca(ficha);
                }

            }
        }
        // Añadimos al array todas las fichas del jugador 2
        if (FichaSeleccionada.GetJugador() == 1)
        {
            fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            datosFichas = FichaSeleccionada.GetFichasJugadores();
            foreach (GameObject ficha in fichas)
            {
                // recorremos todas las fichas asignando el elemento y añadiendo a las fichas seleccionadas
                if (datosFichas[FichaSeleccionada.GetJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 1)
                {
                    CambiaObjeto.AsignaFuegoNegro(ficha);
                }

                if (datosFichas[FichaSeleccionada.GetJugador(), (ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 2)
                {
                    CambiaObjeto.AsignaAguaNegra(ficha);
                }

                if (datosFichas[FichaSeleccionada.GetJugador(),(ficha.GetComponent<numFichaJugador>().idFicha) - 1, FichaSeleccionada.GetCara()] == 3)
                {
                    CambiaObjeto.AsignaMaderaNegra(ficha);
                }

            }
        }
    }
 }
