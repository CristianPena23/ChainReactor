using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GAMEMANAGER : MonoBehaviour
{
    [SerializeField] private AudioClip m_correctsound = null;
    [SerializeField] private AudioClip m_incorrectsound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectoColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;

    private BASEDEDATOS m_quizbase = null;
    private QUIZ_UI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private int m_preguntasRespondidas = 0;
    [SerializeField] private int m_totalPreguntas = 10;

    private int m_puntaje = 0;

    private void Start()
    {
        m_quizbase = FindFirstObjectByType<BASEDEDATOS>();
        m_quizUI = FindFirstObjectByType<QUIZ_UI>();
        m_audioSource = GetComponent<AudioSource>();

        NextQuestion();
    }

    private void NextQuestion()
    {
        m_quizUI.Construct(m_quizbase.GetRandom(), Giveanswer);
    }

    private void Giveanswer(OPCIONBUTTON boton)
    {
        StartCoroutine(GiveanswerRoutine(boton));
    }

    private IEnumerator GiveanswerRoutine(OPCIONBUTTON boton)
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();

        m_audioSource.clip = boton.opcion.correct ? m_correctsound : m_incorrectsound;
        boton.SetColor(boton.opcion.correct ? m_correctColor : m_incorrectoColor);
        m_audioSource.Play();

        // 🎯 Aumenta o disminuye el puntaje según la respuesta
        if (boton.opcion.correct)
        {
            m_puntaje += 200;
            Debug.Log("✅ Respuesta correcta. Puntaje actual: " + m_puntaje);
        }
        else
        {
            m_puntaje -= 100;
            if (m_puntaje < 0) m_puntaje = 0; // 🛡️ No dejes que baje de 0
            Debug.Log("❌ Respuesta incorrecta. Puntaje actual: " + m_puntaje);
        }

        yield return new WaitForSeconds(m_waitTime);

        m_preguntasRespondidas++;

        if (m_preguntasRespondidas >= m_totalPreguntas)
        {
            Debug.Log("🎉 Fin del juego - Puntaje final: " + m_puntaje);

            PlayerPrefs.SetInt("PuntajeFinal", m_puntaje);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Ranking");
            yield break;
        }

        NextQuestion();
    }
}
