using UnityEngine;
using UnityEngine.SceneManagement;

public class niveles : MonoBehaviour
{
    public void Jugar()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene("Scenes/Inicio");
        Debug.Log("Ir a Menu-Inicio");
    }
}
