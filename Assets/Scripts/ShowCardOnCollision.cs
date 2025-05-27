using UnityEngine;
using UnityEngine.UI;

public class ShowCardOnCollision : MonoBehaviour
{
    [Header("Prefab Canvas carta")]
    public GameObject cardCanvasPrefab;  // Prefab que tiene Image, Button Next y Image+Button Close

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

        // Busca el componente Image que mostrará las imágenes de la carta
        cardImageComponent = cardInstance.GetComponentInChildren<Image>();
        if (cardImageComponent == null)
        {
            Debug.LogError("No se encontró componente Image en el prefab Canvas.");
            return;
        }

        if (cardImages.Length == 0)
        {
            Debug.LogWarning("No se asignaron imágenes para la carta.");
            return;
        }

        currentImageIndex = 0;
        cardImageComponent.sprite = cardImages[currentImageIndex];

        // Buscar botones por nombre: Next y Close (imagen con Button)
        Button[] buttons = cardInstance.GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            string name = btn.gameObject.name.ToLower();
            if (name.Contains("next"))
            {
                nextButton = btn;
                nextButton.onClick.AddListener(ShowNextImage);
            }
            else if (name.Contains("close"))
            {
                closeButton = btn;
                closeButton.onClick.AddListener(CloseCard);
            }
        }

        cardActive = true;
    }

    private void ShowNextImage()
    {
        currentImageIndex++;
        if (currentImageIndex >= cardImages.Length)
        {
            if (nextButton != null)
                nextButton.gameObject.SetActive(false);
            return;
        }
        cardImageComponent.sprite = cardImages[currentImageIndex];
    }

    public void CloseCard()
    {
        if (cardInstance != null)
            Destroy(cardInstance);

        Destroy(gameObject); // Destruye el plane para que no vuelva a aparecer
    }
}