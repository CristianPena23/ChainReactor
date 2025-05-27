using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    
    [SerializeField] private Text  m_textoPuntaje= null;
    private void Start()
    {
        int puntaje = PlayerPrefs.GetInt("PuntajeFinal", 0);
        m_textoPuntaje.text = puntaje.ToString();
    }
}
