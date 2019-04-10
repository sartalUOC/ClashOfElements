using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementoSeleccionado : MonoBehaviour
{

    // Para controlar que ya se ha seleccionado un elemento
    static protected int seleccionadoElemento = 0;
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
            if (seleccionadoElemento == 1 && elementoSeleccionado == this.GetComponent<Elementos>().idElemento)
            {
                this.PintaBlanco(this.gameObject);
                seleccionadoElemento = 0;
                elementoSeleccionado = 0;
                //Debug.Log("Limpiamos elemento " + this.name);
            }
            else
            {
                if (elementoSeleccionado == 1) this.PintaBlanco(fuego.gameObject);
                if (elementoSeleccionado == 2) this.PintaBlanco(agua.gameObject);
                if (elementoSeleccionado == 3) this.PintaBlanco(madera.gameObject);
                this.PintaVerde(this.gameObject);
                seleccionadoElemento = 1;
                elementoSeleccionado = this.GetComponent<Elementos>().idElemento;
                //Debug.Log("Seleccionamos elemento " + this.name);
            }
        }
        else
        // Si hay fichas del jugador seleccionadas, las pondremos del material correspondiente al elemento y quitaremos todas las selecciones
        {
            GameObject[] fichas = null;
            // Añadimos al array todas las fichas del jugador 1
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
            {
                fichas = GameObject.FindGameObjectsWithTag("FichasJugador1");
            }
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                fichas = GameObject.FindGameObjectsWithTag("FichasJugador2");
            }

            elementoSeleccionado = this.GetComponent<Elementos>().idElemento;
            int count = 0;
            foreach (GameObject ficha in fichas)
            {
                if (FichaSeleccionada.GetFichasSeleccionadas()[count] == 1)
                {
                    // recorremos todas las fichas asignando el elemento y añadiendo a las fichs seleccionadas
                    if (GetElementoSeleccionado() == 1)
                    {
                        this.AsignaFuego(ficha);
                    }

                    if (GetElementoSeleccionado() == 2)
                    {
                        this.AsignaAgua(ficha);
                    }

                    if (GetElementoSeleccionado() == 3)
                    {
                        this.AsignaMadera(ficha);
                    }

                    if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
                    {
                        FichaSeleccionada.SetFichasJugador1(ficha);
                        this.PintaBlanco(ficha);
                    }
                    if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
                    {
                        FichaSeleccionada.SetFichasJugador2(ficha);
                        this.PintaBlanco(ficha);
                    }
                }

                count ++;
            }
            elementoSeleccionado = 0;
            FichaSeleccionada.InicializaFichasSeleccionadas();
        }
    }

    // Pone el objeto de color verde
    private void PintaVerde(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }
    }

    // Pone el objeto de color blanco
    private void PintaBlanco(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el objeto de color gris
    private void PintaGris(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.grey;
            r.material = m;
        }
    }

    // Pone el material de madera al objeto
    private void AsignaMadera(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaMadera;
            r.material = m;
        }
    }

    // Pone el material de agua al objeto
    private void AsignaAgua(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaAgua;
            r.material = m;
        }
    }

    // Pone el material de fuego al objeto
    private void AsignaFuego(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<FichaSeleccionada>().texturaFuego;
            r.material = m;
        }
    }


}
