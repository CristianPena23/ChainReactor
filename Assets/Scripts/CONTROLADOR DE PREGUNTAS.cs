using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Pregunta
{
    public string preguntaTexto;
    public string[] opciones = new string[3];
    public int respuestaCorrecta; // 0 = A, 1 = B, 2 = C
}

public class ControladorPreguntas : MonoBehaviour
{
    public Text textoPantallita; // Texto que muestra la pregunta y respuestas
    public Button botonA, botonB, botonC; // Botones A, B y C

    private List<Pregunta> preguntas = new List<Pregunta>();
    private Pregunta preguntaActual;

    void Start()
    {
        CargarPreguntas();
        MostrarPreguntaAleatoria();
    }

    void CargarPreguntas()
    {
        preguntas.Add(new Pregunta
        {
            preguntaTexto = "¿Cuál de los siguientes es un polímero lineal?",
            opciones = new string[] { "Baquelita", "Polietileno", "Caucho Vulcanizado" },
            respuestaCorrecta = 1
        });

        preguntas.Add(new Pregunta
        {
            preguntaTexto = "¿Qué clases de polímeros existen?",
            opciones = new string[] { "Lineal, ramificado y reticulado", "Lineal, dual y triádico", "Lineal, fractal y helicoidal" },
            respuestaCorrecta = 0
        });

        preguntas.Add(new Pregunta
        {
            preguntaTexto = "Los polímeros están formados por unidades repetitivas llamadas...",
            opciones = new string[] { "Proteínas", "Monómeros", "Ácido" },
            respuestaCorrecta = 1
        });
    }

    void MostrarPreguntaAleatoria()
    {
        preguntaActual = preguntas[Random.Range(0, preguntas.Count)];

        textoPantallita.text = preguntaActual.preguntaTexto + "\n\n" +
                               "A) " + preguntaActual.opciones[0] + "\n" +
                               "B) " + preguntaActual.opciones[1] + "\n" +
                               "C) " + preguntaActual.opciones[2];

        // Configurar eventos de los botones
        botonA.onClick.RemoveAllListeners();
        botonA.onClick.AddListener(() => VerificarRespuesta(0));

        botonB.onClick.RemoveAllListeners();
        botonB.onClick.AddListener(() => VerificarRespuesta(1));

        botonC.onClick.RemoveAllListeners();
        botonC.onClick.AddListener(() => VerificarRespuesta(2));
    }

    void VerificarRespuesta(int seleccion)
    {
        if (seleccion == preguntaActual.respuestaCorrecta)
        {
            Debug.Log("¡Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
        }

        MostrarPreguntaAleatoria();
    }
}