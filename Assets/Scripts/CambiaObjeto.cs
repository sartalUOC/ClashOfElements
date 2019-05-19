using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaObjeto : MonoBehaviour
{

    // Quita el material que hace referencia al elemento de un objeto
    public static void QuitaMaterial(GameObject objeto)
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

    // Pone el objeto de color verde
    public static void PintaVerde(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }
    }

    // Pone el objeto de color rojo
    public static void PintaRojo(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.red;
            r.material = m;
        }
    }

    // Pone el objeto de color blanco
    public static void PintaBlanco(GameObject objeto)
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
    public static void PintaGris(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.grey;
            r.material = m;
        }
    }

    // Pone el objeto de color Negro
    public static void PintaNegro(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.black;
            r.material = m;
        }
    }

    // Pone el material de madera al objeto
    public static void AsignaMaderaBlanca(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaMaderaBlanca;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el material de madera Negra al objeto
    public static void AsignaMaderaNegra(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaMaderaNegra;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el material de agua al objeto
    public static void AsignaAguaBlanca(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaAguaBlanca;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el material de agua negra al objeto
    public static void AsignaAguaNegra(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaAguaNegra;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el material de fuego al objeto
    public static void AsignaFuegoBlanco(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaFuegoBlanca;
            m.color = Color.white;
            r.material = m;
        }
    }

    // Pone el material de fuego negro al objeto
    public static void AsignaFuegoNegro(GameObject objeto)
    {
        Renderer[] rs = objeto.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.mainTexture = objeto.GetComponent<numFichaJugador>().texturaFuegoNegra;
            m.color = Color.white;
            r.material = m;
        }
    }

}
