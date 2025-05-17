using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private void Start()
    {
        m_quizbase = FindFirstObjectByType<BASEDEDATOS>(); // ← método actualizado
        m_quizUI = FindFirstObjectByType<QUIZ_UI>();       // ← método actualizado
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

        yield return new WaitForSeconds(m_waitTime);

        NextQuestion();
    }
}
