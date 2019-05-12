using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElementoSeleccionado : MonoBehaviour
{

    // Que elemento está seleccionado
    static protected int elementoSeleccionado = 0;

    GameObject fuego, agua, madera;

    // Start is called before the first frame update
    void Start()
    {
        fuego = GameObject.FindGameObjectWithTag("Fuego");
        agua = GameObject.FindGameObjectWithTag("Agua");
        madera = GameObject.FindGameObjectWithTag("Madera");
    }

    // Devuelve el elemnto seleccionado
    public static int GetElementoSeleccionado()
    {
        return elementoSeleccionado;
    }

    // Asigna el elemento seleccionado
    public static void SetElementoSeleccionado(int elemento)
    {
        elementoSeleccionado = elemento;
    }

    // Control de la seleccion de elementos
    private void OnMouseUp()
    {
        int numFichasSeleccionadas = FichaSeleccionada.GetTotalFichasSeleccionadas();
        foreach (int i in FichaSeleccionada.GetFichasSeleccionadas())

        // si no hay fichas del jugador seleccionadas marcaremos y/o desmarcaremos el elemento seleccionado. solo puede haber uno
        if (numFichasSeleccionadas == 0)
        {
            if (elementoSeleccionado == this.GetComponent<Elementos>().idElemento)
            {
                CambiaObjeto.PintaBlanco(this.gameObject);
                ElementoSeleccionado.SetElementoSeleccionado(0);
            }
            else
            {
                if (elementoSeleccionado == 1) CambiaObjeto.PintaBlanco(fuego.gameObject);
                if (elementoSeleccionado == 2) CambiaObjeto.PintaBlanco(agua.gameObject);
                if (elementoSeleccionado == 3) CambiaObjeto.PintaBlanco(madera.gameObject);
                CambiaObjeto.PintaVerde(this.gameObject);
                ElementoSeleccionado.SetElementoSeleccionado(this.GetComponent<Elementos>().idElemento);
            }
        }
        else
        // Si hay fichas del jugador seleccionadas, las pondremos del material correspondiente al elemento y quitaremos todas las selecciones
        {
            GameObject[] fichas = null;
            // Añadimos al array todas las fichas del jugador
            if (FichaSeleccionada.GetJugador() == 0)
            {
                fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            }
            if (FichaSeleccionada.GetJugador() == 1)
            {
                fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            }

            elementoSeleccionado = this.GetComponent<Elementos>().idElemento;
            foreach (GameObject ficha in fichas)
            {
                if (FichaSeleccionada.GetFichasSeleccionadas()[ficha.GetComponent<numFichaJugador>().idFicha-1] == 1)
                {
                    // recorremos todas las fichas asignando el elemento y añadiendo a las fichs seleccionadas
                    if (FichaSeleccionada.GetJugador() == 0)
                    {
                        if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                        {
                            CambiaObjeto.AsignaFuegoBlanco(ficha);
                        }

                        if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                        {
                            CambiaObjeto.AsignaAguaBlanca(ficha);
                        }

                        if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                        {
                            CambiaObjeto.AsignaMaderaBlanca(ficha);
                        }
                    }
                    if (FichaSeleccionada.GetJugador() == 1)
                    {
                        if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                        {
                            CambiaObjeto.AsignaFuegoNegro(ficha);
                        }

                        if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                        {
                            CambiaObjeto.AsignaAguaNegra(ficha);
                        }

                        if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                        {
                            CambiaObjeto.AsignaMaderaNegra(ficha);
                        }
                    }
                    FichaSeleccionada.SetFichaJugador(ficha);
                }
            }
            ElementoSeleccionado.SetElementoSeleccionado(0);
            FichaSeleccionada.InicializaFichasSeleccionadas();
        }
    }

 }
