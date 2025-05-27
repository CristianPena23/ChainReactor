using UnityEngine;
using UnityEngine.UI;

public class ShowCardOnCollisionWithImages : MonoBehaviour
{
    [Header("Prefab Canvas Carta")]
    public GameObject cardCanvasPrefab;  // Prefab del Canvas

    [Header("Imágenes de la carta")]
    public Sprite[] cardImages;

    private GameObject cardInstance;
    private Image cardImageComponent;
    private Button nextButton;
    private Button closeButton;

    private int currentImageIndex = 0;
    private bool cardActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!cardActive && other.CompareTag("Player"))
        {
            ShowCard();
        }
    }

    private void ShowCard()
    {
        if (cardCanvasPrefab == null)
        {
            Debug.LogError("No se asignó el prefab del canvas de la carta.");
            return;
        }

        cardInstance = Instantiate(cardCanvasPrefab);

        // Busca el componente Image en el canvas para mostrar las imágenes
        cardImageComponent = cardInstance.GetComponentInChildren<Image>();
        if (cardImageComponent == null)
        {
            Debug.LogError("No se encontró componente Image en el prefab Canvas.");
            return;
        }

        // Asignar la primera imagen
        if (cardImages.Length > 0)
        {
            currentImageIndex = 0;
            cardImageComponent.sprite = cardImages[currentImageIndex];
        }
        else
        {
            Debug.LogWarning("No hay imágenes asignadas para la carta.");
        }

        // Buscar botones en el prefab (Next y Close)
        Button[] buttons = cardInstance.GetComponentsInChildren<Button>();
        foreach (var btn in buttons)
        {
            if (btn.name.ToLower().Contains("next"))
                nextButton = btn;
            else if (btn.name.ToLower().Contains("close"))
                closeButton = btn;
        }

        // Asignar listeners a botones
        if (nextButton != null)
            nextButton.onClick.AddListener(ShowNextImage);

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseCard);

        cardActive = true;
    }

    private void ShowNextImage()
    {
        if (cardImages.Length == 0) return;

        currentImageIndex++;

        if (currentImageIndex >= cardImages.Length)
        {
            // Opcional: cuando se acaban las imágenes, ocultar botón next o cerrar la carta
            nextButton.gameObject.SetActive(false);
            return;
        }

        cardImageComponent.sprite = cardImages[currentImageIndex];
    }

    public void CloseCard()
    {
        if (cardInstance != null)
        {
            Destroy(cardInstance);
        }

        Destroy(gameObject);
    }
}