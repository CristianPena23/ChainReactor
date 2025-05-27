using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InfoWindowManager : MonoBehaviour
{
    [Header("Prefab y tamaño")]
    public GameObject infoWindowPrefab; // Asignar prefab aquí
    public Vector2 windowSize = new Vector2(200, 200);

    [Header("Imágenes y tiempos")]
    public List<Sprite> images; // Asignar sprites aquí
    public float initialDelay = 5f;   // Espera antes de mostrar primera ventana
    public float showDuration = 30f;  // Tiempo visible ventana
    public float hiddenDuration = 15f; // Tiempo oculta entre ventanas

    private GameObject windowInstance;
    private Image infoImage;

    IEnumerator Start()
    {
        // Buscar Canvas activo en la escena
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No hay Canvas en la escena.");
            yield break;
        }

        // Verificar que el prefab esté asignado
        if (infoWindowPrefab == null)
        {
            Debug.LogError("No asignaste infoWindowPrefab en el Inspector.");
            yield break;
        }

        // Instanciar el prefab dentro del Canvas
        windowInstance = Instantiate(infoWindowPrefab, canvas.transform);
        windowInstance.GetComponent<RectTransform>().sizeDelta = windowSize;

        // Buscar el componente Image en los hijos del prefab
        infoImage = windowInstance.GetComponentInChildren<Image>();
        if (infoImage == null)
        {
            Debug.LogError("No se encontró componente Image dentro del prefab.");
            yield break;
        }

        // Iniciar con la ventana oculta
        windowInstance.SetActive(false);

        // Verificar que la lista de imágenes no esté vacía
        if (images == null || images.Count == 0)
        {
            Debug.LogWarning("Lista de imágenes vacía.");
            yield break;
        }

        // Esperar el tiempo inicial antes de mostrar la ventana
        yield return new WaitForSeconds(initialDelay);

        // Mostrar cada imagen en orden, con los tiempos indicados
        for (int i = 0; i < images.Count; i++)
        {
            infoImage.sprite = images[i];
            windowInstance.SetActive(true);

            // Mostrar imagen el tiempo de showDuration
            yield return new WaitForSeconds(showDuration);

            windowInstance.SetActive(false);

            // Esperar tiempo oculto solo si no es la última imagen
            if (i < images.Count - 1)
                yield return new WaitForSeconds(hiddenDuration);
        }

        // Asegurar que la ventana quede oculta al finalizar
        windowInstance.SetActive(false);
    }

    // Método para detener el ciclo en cualquier momento
    public void StopCycle()
    {
        StopAllCoroutines();
        if (windowInstance != null)
            windowInstance.SetActive(false);
    }
}