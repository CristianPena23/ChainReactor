using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionPreguntas : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelFinal;                // El canvas o panel final que debe mostrarse primero
    public CanvasGroup faderCanvasGroup;         // El panel negro con CanvasGroup para el fade
    public string nombreEscenaDestino = "preguntasN1";

    [Header("Tiempos")]
    public float tiempoEsperaDespuesDePanel = 2f;
    public float tiempoFadeOut = 1.5f;

    private bool transicionIniciada = false;

    void Update()
    {
        if (!transicionIniciada && panelFinal.activeInHierarchy)
        {
            transicionIniciada = true;
            StartCoroutine(FadeYTransicion());
        }
    }

    private IEnumerator FadeYTransicion()
    {
        yield return new WaitForSeconds(tiempoEsperaDespuesDePanel);

        faderCanvasGroup.gameObject.SetActive(true);
        faderCanvasGroup.alpha = 0f;

        // Fade hacia negro
        LeanTween.alphaCanvas(faderCanvasGroup, 1f, tiempoFadeOut);
        yield return new WaitForSeconds(tiempoFadeOut);

        SceneManager.LoadScene(nombreEscenaDestino);
    }
}