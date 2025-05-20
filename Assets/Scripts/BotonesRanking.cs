using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesRanking : MonoBehaviour
{
    public void Settings()
    {
        SceneManager.LoadScene("Scenes/Settings");
        Debug.Log("Ir a Setttings");
    }
    public void Back()
    {
        SceneManager.LoadScene("Scenes/Inicio");
        Debug.Log("Ir a Menu-Inicio");
    }
}
