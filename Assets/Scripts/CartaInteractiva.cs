using UnityEngine;
using UnityEngine.UI;

public class CartaInteractiva : MonoBehaviour
{
    [Header("Nombre del Canvas hijo (debe estar desactivado al inicio)")]
    public string nombreCanvas = "CanvasCarta";

    private GameObject canvasCarta;
    private Button botonCerrar;
    private bool abierta = false;

    void Start()
    {
        // Buscar el Canvas hijo por nombre
        Transform canvasTransform = transform.Find(nombreCanvas);
        if (canvasTransform != null)
        {
            canvasCarta = canvasTransform.gameObject;
            canvasCarta.SetActive(false);
        }
        else
        {
            Debug.LogError("❌ No se encontró un hijo llamado " + nombreCanvas + " en " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!abierta && other.CompareTag("Player"))
        {
            AbrirCarta();
        }
    }

    void AbrirCarta()
    {
        if (canvasCarta == null) return;

        canvasCarta.SetActive(true);
        abierta = true;

        // Buscar el botón de cierre
        botonCerrar = canvasCarta.transform.Find("ButtonCerrar")?.GetComponent<Button>();
        if (botonCerrar != null)
        {
            botonCerrar.onClick.RemoveAllListeners();
            botonCerrar.onClick.AddListener(CerrarCarta);
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró un botón llamado 'ButtonCerrar' en el CanvasCarta.");
        }

        Debug.Log("✅ Carta abierta: " + gameObject.name);
    }

    void CerrarCarta()
    {
        if (canvasCarta != null)
            canvasCarta.SetActive(false);

        Destroy(gameObject); // Opcional: destruye la carta tras verla
    }

    // 💡 Prueba manual (opcional) por si el trigger no funciona
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("🧪 Tecla T presionada: abriendo carta manualmente");
            AbrirCarta();
        }
    }
}
