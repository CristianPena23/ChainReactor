using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SonidosBotones : MonoBehaviour
{
    public AudioClip sonidoAlClic;
    public string escenaDestino; // Si está vacío, se regresará a la escena anterior guardada

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() =>
            {
                ReproducirYEsperar();
            });
        }
    }

    void ReproducirYEsperar()
    {
        if (sonidoAlClic != null)
        {
            audioSource.PlayOneShot(sonidoAlClic);
            Invoke(nameof(CambiarEscena), sonidoAlClic.length);
        }
        else
        {
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        if (!string.IsNullOrEmpty(escenaDestino))
        {
            // Guardamos la escena actual antes de cambiar, útil si queremos volver
            PlayerPrefs.SetString("escena_anterior", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(escenaDestino);
        }
        else
        {
            // Volver a la anterior si no se definió un destino explícito
            string escenaAnterior = PlayerPrefs.GetString("escena_anterior", "MenuPrincipal");
            SceneManager.LoadScene(escenaAnterior);
        }
    }
}
