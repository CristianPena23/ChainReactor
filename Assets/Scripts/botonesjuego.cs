using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesjuego : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Salir()
{
    Debug.Log("Salir...");
    Application.Quit();
}
  public void Settings()
{
    SceneManager.LoadScene("Scenes/Settings");
    Debug.Log("Ir a Setttings");
}
}