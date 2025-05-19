using UnityEngine;
using TMPro;

public class RankingUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_textoPuntaje = null;

    private void Start()
    {
        int puntaje = PlayerPrefs.GetInt("PuntajeFinal", 0);
        m_textoPuntaje.text = "Tu puntaje fue: " + puntaje.ToString();
    }
}
