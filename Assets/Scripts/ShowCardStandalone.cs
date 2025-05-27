using UnityEngine;
using UnityEngine.UI;

public class ShowCardStandalone : MonoBehaviour
{
    private GameObject canvasCarta;
    private Button botonCerrar;
    private bool cartaMostrada = false;

    private void Start()
    {
        // Buscar el Canvas hijo (debe estar desactivado por defecto)
        canvasCarta = transform.Find("CanvasCarta")?.gameObject;
        if (canvasCarta != null)
            canvasCarta.SetActive(false); // asegurarse que esté oculto
        else
            Debug.LogError("No se encontró un objeto hijo llamado 'CanvasCarta'.");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.name);

        if (!cartaMostrada && other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado. Mostrando carta...");
            ShowCard();
        }
    }

    void CerrarCarta()
    {
        if (canvasCarta != null)
            canvasCarta.SetActive(false);

        Destroy(gameObject); // Destruye la carta del mundo tras verla
    }
}