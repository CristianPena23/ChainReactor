using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesSettings : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Scenes/Inicio");
        Debug.Log("Ir a Menu-Inicio");
    }

    public void Back()
    {
        SceneManager.LoadScene("Scenes/Inicio");
        Debug.Log("Ir a Menu-Inicio");
    }
}
