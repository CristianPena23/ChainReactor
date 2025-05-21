using UnityEngine;
using UnityEngine.UI;

public class SecuencialEnlaceDetector : MonoBehaviour
{
    [System.Serializable]
    public struct PasoDeEnlace
    {
        public string tagEsperado;
        public Transform puntoDeEnlace; // EnlaceH1, EnlaceH2, etc.
    }

    public PasoDeEnlace[] pasos;
    public float anguloPermitido = 15f;
    public float distanciaMaxima = 1f;
    public GameObject prefabCilindro;
    public Camera camaraNormal;
    public Camera camaraFinal;
    public GameObject panelFinal;

    private int pasoActual = 0;

    void Start()
    {
        if (camaraFinal != null) camaraFinal.gameObject.SetActive(false);
        if (panelFinal != null) panelFinal.SetActive(false);
    }

    void Update()
    {
        if (pasoActual >= pasos.Length) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PasoDeEnlace paso = pasos[pasoActual];

            Collider[] posibles = Physics.OverlapSphere(paso.puntoDeEnlace.position, distanciaMaxima);
            foreach (Collider c in posibles)
            {
                if (c.CompareTag(paso.tagEsperado))
                {
                    Vector3 direccionAlObjetivo = (c.transform.position - paso.puntoDeEnlace.position).normalized;
                    float angulo = Vector3.Angle(paso.puntoDeEnlace.forward, direccionAlObjetivo);

                    if (angulo <= anguloPermitido)
                    {
                        Debug.Log("\u2705 Enlace correcto con " + c.name);

                        // Instanciar cilindro
                        if (prefabCilindro)
                        {
                            GameObject cilindro = Instantiate(prefabCilindro);
                            Vector3 midPoint = (paso.puntoDeEnlace.position + c.transform.position) / 2f;
                            cilindro.transform.position = midPoint;
                            cilindro.transform.up = (c.transform.position - paso.puntoDeEnlace.position).normalized;
                            float dist = Vector3.Distance(paso.puntoDeEnlace.position, c.transform.position);
                            cilindro.transform.localScale = new Vector3(0.1f, dist / 2f, 0.1f);
                        }

                        // Fijar y pasar al siguiente
                        c.transform.SetParent(paso.puntoDeEnlace);
                        c.transform.position = paso.puntoDeEnlace.position;
                        pasoActual++;

                        if (pasoActual >= pasos.Length)
                        {
                            Invoke(nameof(FinalizarNivel), 1.5f);
                        }
                        return;
                    }
                    else
                    {
                        Debug.LogWarning("\u274C Ángulo incorrecto con " + c.name + " (" + angulo.ToString("F1") + "°)");
                    }
                }
            }
        }
    }

    void FinalizarNivel()
    {
        if (camaraNormal != null) camaraNormal.gameObject.SetActive(false);
        if (camaraFinal != null) camaraFinal.gameObject.SetActive(true);
        if (panelFinal != null) panelFinal.SetActive(true);

        Debug.Log("\ud83c\udf89 Nivel completado");
    }
}
