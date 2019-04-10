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
    static protected int[,] fichasJugador1 = new int[9,4]; //x, y, z y elemento
    static protected int[,] fichasJugador2 = new int[9, 4]; //x, y, z y elemento

    // Asignación de texturas posibles de las fichas
    public Texture texturaMadera;
    public Texture texturaAgua;
    public Texture texturaFuego;
    
    // Comportamiento al pinchar
    private void OnMouseUp()
    {
        // Si no hay elemento seleccionado permitiremos ir seleccionando o deseleccinando varias fichas del jugador1
        if (ElementoSeleccionado.GetElementoSeleccionado() == 0)
        {
            // Si la ficha no estaba seleccionada la marcamos de verde, si ya estaba seleccionada la ponemos blanca
            if (fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] == 0)
            {
                this.PintaVerde(this.gameObject);
                fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] = 1;
                totalFichasSeleccionadas++;
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
                {
                    this.PintaBlanco(this.gameObject);
                }
                if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
                {
                    this.PintaGris(this.gameObject);
                }
                fichasSeleccionadas[this.GetComponent<numFichaJugador>().idFicha-1] = 0;
                totalFichasSeleccionadas--;
            }

            //Debug.Log("Click! en ficha");

        }
        else
        // Si hay un elemento seleccionado, cambiaremos el material de la ficha
        {
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador1")
            {
                // Si la ficha ya tiene ese elemento se lo quitaremos
                if (ElementoSeleccionado.GetElementoSeleccionado() == fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 3])
                {
                    this.QuitaMaterial(this.gameObject);
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 0] = 0;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 1] = 0;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 2] = 0;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 3] = 0;
                }
                else // Si la ficha no tiene ese elemento, le asignaremos el elemento seleccionado independientemente del elemento que tuviera la ficha anteriormente
                {
                    if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                    {
                        this.AsignaFuego(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                    {
                        this.AsignaAgua(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                    {
                        this.AsignaMadera(this.gameObject);
                    }
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 0] = (int)this.gameObject.transform.position.x;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 1] = (int)this.gameObject.transform.position.y;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 2] = (int)this.gameObject.transform.position.z;
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 3] = ElementoSeleccionado.GetElementoSeleccionado();
                }
            }
            // repetimos para el jugador 2 si estamos en la escena correspondiente
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                if (ElementoSeleccionado.GetElementoSeleccionado() == fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 3])
                {
                    this.QuitaMaterial(this.gameObject);
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 0] = 0;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 1] = 0;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 2] = 0;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 3] = 0;
                }
                else
                {
                    if (ElementoSeleccionado.GetElementoSeleccionado() == 1)
                    {
                        this.AsignaFuego(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 2)
                    {
                        this.AsignaAgua(this.gameObject);
                    }

                    if (ElementoSeleccionado.GetElementoSeleccionado() == 3)
                    {
                        this.AsignaMadera(this.gameObject);
                    }
                    fichasJugador1[this.GetComponent<numFichaJugador>().idFicha - 1, 0] = (int)this.gameObject.transform.position.x;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 1] = (int)this.gameObject.transform.position.y;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 2] = (int)this.gameObject.transform.position.z;
                    fichasJugador2[this.GetComponent<numFichaJugador>().idFicha - 1, 3] = ElementoSeleccionado.GetElementoSeleccionado();

                }
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

    // devuelve las fichas del jugador 1
    public static int[,] GetFichasJugador1()
    {
        return fichasJugador1;
    }

    // devuelve las fichas del jugador 2
    public static int[,] GetFichasJugador2()
    {
        return fichasJugador2;
    }

    // Guarda los datos de una ficha (posición y elemento) para el jugador 1
    public static void SetFichasJugador1(GameObject obj)
    {
        fichasJugador1[obj.GetComponent<numFichaJugador>().idFicha - 1, 0] = (int)obj.transform.position.x;
        fichasJugador1[obj.GetComponent<numFichaJugador>().idFicha - 1, 1] = (int)obj.transform.position.y;
        fichasJugador1[obj.GetComponent<numFichaJugador>().idFicha - 1, 2] = (int)obj.transform.position.z;
        fichasJugador1[obj.GetComponent<numFichaJugador>().idFicha - 1, 3] = ElementoSeleccionado.GetElementoSeleccionado();
    }

    // Guarda los datos de una ficha (posición y elemento) para el jugador 2
    public static void SetFichasJugador2(GameObject obj)
    {
        fichasJugador2[obj.GetComponent<numFichaJugador>().idFicha - 1, 0] = (int)obj.transform.position.x;
        fichasJugador2[obj.GetComponent<numFichaJugador>().idFicha - 1, 1] = (int)obj.transform.position.y;
        fichasJugador2[obj.GetComponent<numFichaJugador>().idFicha - 1, 2] = (int)obj.transform.position.z;
        fichasJugador2[obj.GetComponent<numFichaJugador>().idFicha - 1, 3] = ElementoSeleccionado.GetElementoSeleccionado();
    }

    // Inicializa las posiciones y elementos de las fichas del jugador 1
    public static void InicializaFichasJugador1()
    {
        for (int i = 0; i < 9; i++)
        {
            fichasJugador1[i, 0] = 0;
            fichasJugador1[i, 1] = 0;
            fichasJugador1[i, 2] = 0;
            fichasJugador1[i, 3] = 0;
        }
    }

    // Inicializa las posiciones y elementos de las fichas del jugador 2
    public static void InicializaFichasJugador2()
    {
        for (int i = 0; i < 9; i++)
        {
            fichasJugador2[i, 0] = 0;
            fichasJugador2[i, 1] = 0;
            fichasJugador2[i, 2] = 0;
            fichasJugador2[i, 3] = 0;
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

    // Quita el material que hace referencia al elemento de un objeto
    private void QuitaMaterial(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = null;
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                m.color = Color.grey;
            }
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
            m.mainTexture=texturaMadera;
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                m.color = Color.white;
            }
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
            m.mainTexture = texturaAgua;
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                m.color = Color.white;
            }
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
            m.mainTexture = texturaFuego;
            if (SceneManager.GetActiveScene().name == "Selector Fichas Jugador2")
            {
                m.color = Color.white;
            }
            r.material = m;
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


}
