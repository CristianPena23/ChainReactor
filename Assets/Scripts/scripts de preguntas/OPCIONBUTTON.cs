using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OPCIONBUTTON : MonoBehaviour
{
    private Button m_button = null;
    private Image m_Image = null;
    private Text m_text = null;
    private Color m_originalColor = Color.black;

    public opcion opcion { get; set; }

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_Image = GetComponent<Image>();
        m_text = transform.GetChild(0).GetComponent<Text>();
        m_originalColor = m_Image.color;
    }

    public void Construct(opcion opcion, Action<OPCIONBUTTON> callback)
    {
        this.opcion = opcion;
        m_text.text = opcion.text;

        m_button.onClick.RemoveAllListeners(); // 🔥 ¡Clave para evitar duplicados!
        m_button.enabled = true;
        m_Image.color = m_originalColor;

        m_button.onClick.AddListener(delegate {
            callback(this);
        });
    }

    public void SetColor(Color c)
    {
        m_button.enabled = false;
        m_Image.color = c;
    }
}
