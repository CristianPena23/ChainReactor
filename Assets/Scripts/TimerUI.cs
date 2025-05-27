using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerUI : MonoBehaviour
{
    
    public static int monomerosCorrectos = 0; // Se incrementa desde cualquier parte
    public float tiempoLimite = 360f; // 6 minutos
    private float tiempoActual;
    private bool tiempoTerminado = false;

    public Text textoTimer;
    public Text textoResultado;

    public Camera camaraNormal;
    public Camera camaraFinal;
    public GameObject panelFinal;

    void Start()
    {
        tiempoActual = tiempoLimite;

        if (camaraFinal != null) camaraFinal.gameObject.SetActive(false);
        if (panelFinal != null) panelFinal.SetActive(false);
    }

    void Update()
    {
        if (tiempoTerminado) return;

        tiempoActual -= Time.deltaTime;
        ActualizarUI();

        if (tiempoActual <= 0)
        {
            tiempoTerminado = true;
            tiempoActual = 0;
            FinalizarPorTiempo();
        }
    }

    void ActualizarUI()
    {
        TimeSpan tiempo = TimeSpan.FromSeconds(tiempoActual);
        if (textoTimer != null)
        {
            textoTimer.text = string.Format("{0:00}:{1:00}", tiempo.Minutes, tiempo.Seconds);
        }
    }

    void FinalizarPorTiempo()
    {
        if (camaraNormal != null) camaraNormal.gameObject.SetActive(false);
        if (camaraFinal != null) camaraFinal.gameObject.SetActive(true);
        if (panelFinal != null) panelFinal.SetActive(true);

        int noEnlazados = 5 - TimerUI.monomerosCorrectos;
        if (noEnlazados < 0) noEnlazados = 0;

        if (textoResultado != null)
            textoResultado.text = "Monómeros no enlazados correctamente: " + noEnlazados;

        Debug.Log("⏰ Tiempo agotado. Monómeros sin enlazar: " + noEnlazados);

    }

    int ContarMonomerosNoEnlazados()
    {
        GameObject[] todos = GameObject.FindGameObjectsWithTag("Monomero");
        int incorrectos = 0;

        foreach (GameObject mono in todos)
        {
            MonomeroInfo info = mono.GetComponent<MonomeroInfo>();
            if (info != null && !info.estaEnlazadoCorrectamente)
            {
                incorrectos++;
            }
        }

        return incorrectos;
    }
}
