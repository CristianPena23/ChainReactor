using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstruccionesManager : MonoBehaviour
{
    [Header("Contenido")]
    public Sprite[] instrucciones;              // Arreglo de sprites para cada diapositiva
    public Image contenidoInstruccion;          // Imagen donde se muestra la instrucción actual

    [Header("Botones")]
    public Button botonAnterior;                // Botón de flecha izquierda
    public Button botonSiguiente;               // Botón de flecha derecha
    public Button botonComenzar;                // Botón para iniciar el juego (solo aparece al final)


    private int indiceActual = 0;

    void Start()
    {
        MostrarInstruccion();
    }

    public void Siguiente()
    {
        if (indiceActual < instrucciones.Length - 1)
        {
            indiceActual++;
            MostrarInstruccion();
        }
    }

    public void Anterior()
    {
        if (indiceActual > 0)
        {
            indiceActual--;
            MostrarInstruccion();
        }
    }

    void MostrarInstruccion()
    {
        // Mostrar el sprite correspondiente a la instrucción actual
        contenidoInstruccion.sprite = instrucciones[indiceActual];

        // Control de visibilidad de botones
        botonAnterior.gameObject.SetActive(indiceActual > 0);                                      // Mostrar ← solo si no estamos en la primera
        botonSiguiente.gameObject.SetActive(indiceActual < instrucciones.Length - 1);              // Mostrar → solo si no estamos en la última
        botonComenzar.gameObject.SetActive(indiceActual == instrucciones.Length - 1);              // Mostrar "Comenzar" solo en la última
;
    }

    public void ComenzarJuego()
    {
        // Cambia esto por el nombre real de la escena de tu juego
        SceneManager.LoadScene("Scenes/Niveles");
    }
}