using UnityEngine;
using UnityEngine.UI;

public class InstruccionesManager : MonoBehaviour
{
    public Sprite[] instrucciones;           // Array de sprites con las instrucciones
    public Image panelImagen;                // UI Image donde se muestran
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
        panelImagen.sprite = instrucciones[indiceActual];
    }
}
