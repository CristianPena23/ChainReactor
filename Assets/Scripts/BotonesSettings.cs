using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BotonesSettings : MonoBehaviour
{
    [SerializeField] private float delayAntesDeCambiar = 0.5f;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Home()
    {
        StartCoroutine(ReproducirSonidoYEscena("Inicio")); // 👈 Tu escena debe llamarse exactamente así
    }

    private IEnumerator ReproducirSonidoYEscena(string nombreEscena)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("⚠️ No hay AudioClip asignado.");
        }

        yield return new WaitForSeconds(delayAntesDeCambiar);
        SceneManager.LoadScene(nombreEscena);
    }
}
