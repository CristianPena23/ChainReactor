using UnityEngine;
using UnityEngine.UI;

public class CartaManager : MonoBehaviour
{
    public static CartaManager instancia;

    public GameObject panelCarta;
    public Image imagenCarta;
    public Text textoCarta;

    void Awake()
    {
        if (instancia == null) instancia = this;
        panelCarta.SetActive(false);
    }

    public void MostrarCarta(Sprite imagen, string texto)
    {
        if (panelCarta != null) panelCarta.SetActive(true);
        if (imagenCarta != null) imagenCarta.sprite = imagen;
        if (textoCarta != null) textoCarta.text = texto;
    }

    public void CerrarCarta()
    {
        panelCarta.SetActive(false);
    }
}
