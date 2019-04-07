using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Para cargar la escena que se indique como parámetro
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
