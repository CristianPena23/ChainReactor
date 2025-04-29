using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour
{
    public void Ranking()
    {
        SceneManager.LoadScene("Scenes/Ranking");
        Debug.Log("Ir a Ranking");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Scenes/Settings");
        Debug.Log("Ir a Setttings");
    }
    public void jugar()
    {
        SceneManager.LoadScene("Scenes/Niveles");
        Debug.Log("Ir a Niveles");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}