using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OPCIONBUTTON : MonoBehaviour
{
    public Font fuenteDeseada;  // Asigna la fuente en el inspector

    private Button m_button = null;
    private Image m_Image = null;

    [SerializeField] private Text m_text = null;  // Puedes asignar el Text desde inspector para mayor control
    private Color m_originalColor = Color.black;

    public opcion opcion { get; set; }

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_Image = GetComponent<Image>();

        // Si no asignaste m_text en el inspector, intenta buscarlo en el primer hijo
        if (m_text == null)
        {
            if (transform.childCount > 0)
            {
                m_text = transform.GetChild(0).GetComponent<Text>();
                if (m_text == null)
                {
                    Debug.LogError("El hijo 0 no tiene componente Text.");
                }
            }
            else
            {
                Debug.LogError("No hay hijos en el objeto para obtener el componente Text.");
            }
        }

        if (m_Image != null)
            m_originalColor = m_Image.color;
        else
            Debug.LogError("No se encontró componente Image en el GameObject.");
    }

    public void Construct(opcion opcion, Action<OPCIONBUTTON> callback)
    {
        if (opcion == null)
        {
            Debug.LogError("La opción pasada a Construct es null");
            return;
        }

        this.opcion = opcion;

        if (fuenteDeseada != null && m_text != null)
        {
            m_text.font = fuenteDeseada;  // Cambia la fuente aquí
        }

        if (m_text != null)
            m_text.text = opcion.text;
        else
            Debug.LogWarning("m_text es null, no se puede asignar texto.");

        if (m_button == null)
        {
            Debug.LogError("m_button es null, no se pueden asignar listeners.");
            return;
        }

        m_button.onClick.RemoveAllListeners(); // Evita duplicados
        m_button.enabled = true;

        if (m_Image != null)
            m_Image.color = m_originalColor;

        m_button.onClick.AddListener(delegate {
            callback(this);
        });
    }

    public void SetColor(Color c)
    {
        if (m_button != null)
            m_button.enabled = false;
        if (m_Image != null)
            m_Image.color = c;
    }
}
