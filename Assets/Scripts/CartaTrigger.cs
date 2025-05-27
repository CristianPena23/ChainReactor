using UnityEngine;

public class CartaTrigger : MonoBehaviour
{
    public Sprite imagenCarta;
    [TextArea]
    public string textoCarta;

    private bool mostrada = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!mostrada && other.CompareTag("Player"))
        {
            if (CartaManager.instancia != null)
                CartaManager.instancia.MostrarCarta(imagenCarta, textoCarta);

            mostrada = true;
        }
    }
}

