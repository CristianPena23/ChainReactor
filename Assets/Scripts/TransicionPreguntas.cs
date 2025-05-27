using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionPreguntas : MonoBehaviour
{
    [Header("Panel negro con CanvasGroup")]
    public CanvasGroup disolverCanvasGroup;

    [Header("Tiempos de transición")]
    public float tiempoDisolverSalida = 1.5f;

    [Header("Nombre de la escena a cargar")]
    public string nombreEscenaSiguiente = "preguntasN1";

    // Llamar esta función desde un botón o trigger
    public void IniciarTransicionAEscena()
    {
        // Asegúrate de que el panel esté visible y encima de todo
        disolverCanvasGroup.alpha = 0f;
        disolverCanvasGroup.blocksRaycasts = true;
        disolverCanvasGroup.interactable = false;

        // Activar el objeto por si estaba desactivado
        disolverCanvasGroup.gameObject.SetActive(true);

        // Empezar transición
        StartCoroutine(TransicionAEscena());
    }

    private IEnumerator TransicionAEscena()
    {
        // === FADE OUT === (de transparente a negro)
        LeanTween.alphaCanvas(disolverCanvasGroup, 1f, tiempoDisolverSalida);
        yield return new WaitForSeconds(tiempoDisolverSalida);

        // === Cargar escena ===
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}