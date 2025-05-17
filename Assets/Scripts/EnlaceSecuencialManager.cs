// ================================
// EnlaceSecuencialManager.cs (Combinado con enlace visual automático)
// ================================

using UnityEngine;
using System.Collections.Generic;

public class EnlaceSecuencialManager : MonoBehaviour
{
    [Header("Orden correcto de enlace (por TAG)")]
    public List<string> secuenciaTags = new List<string> {
        "Carbono", "Hidrogeno", "Hidrogeno", "Hidrogeno", "Hidrogeno"
    };

    [Header("Referencia visual")]
    public Transform player;
    public GameObject bondPrefab;

    private int indiceActual = 0;

    public void IntentarEnlace(GameObject monomero)
    {
        if (indiceActual >= secuenciaTags.Count)
        {
            Debug.Log("✅ Todos los enlaces fueron completados correctamente.");
            return;
        }

        string tagEsperado = secuenciaTags[indiceActual];

        if (monomero.CompareTag(tagEsperado))
        {
            Debug.Log("✅ Enlace correcto: " + tagEsperado);
            CrearEnlaceVisual(player, monomero.transform);
            indiceActual++;
        }
        else
        {
            Debug.LogWarning("❌ Enlace fuera de orden: esperábamos '" + tagEsperado + "' pero recibimos '" + monomero.tag + "'");
            // Aquí luego puedes restar puntos o mostrar un mensaje de error en UI
        }
    }

    void CrearEnlaceVisual(Transform from, Transform to)
    {
        GameObject enlace = Instantiate(bondPrefab);
        Vector3 dir = to.position - from.position;
        enlace.transform.position = (from.position + to.position) / 2f;
        enlace.transform.up = dir.normalized;
        enlace.transform.localScale = new Vector3(0.05f, dir.magnitude / 2f, 0.05f);
    }

    public bool SecuenciaCompleta()
    {
        return indiceActual >= secuenciaTags.Count;
    }

    public void ReiniciarSecuencia()
    {
        indiceActual = 0;
    }
}
