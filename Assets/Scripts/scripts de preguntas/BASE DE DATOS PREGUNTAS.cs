using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BASEDEDATOS : MonoBehaviour
{
    [SerializeField] private List<pregun> m_preguntaslist = null;
    private List<pregun> m_backup = null;

    private void Awake()
    {
        // Copia real de la lista original
        m_backup = new List<pregun>(m_preguntaslist);
    }

    public pregun GetRandom(bool remove = true)
    {
        if (m_preguntaslist.Count == 0)
            RestoreBackup();

        int index = Random.Range(0, m_preguntaslist.Count);

        if (!remove)
            return m_preguntaslist[index];

        pregun q = m_preguntaslist[index];
        m_preguntaslist.RemoveAt(index);
        return q;
    }

    private void RestoreBackup()
    {
        // Restaura la lista original desde el respaldo
        m_preguntaslist = new List<pregun>(m_backup);
    }

    public void Back()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Debug.Log("Ir a Menu-Inicio");
    }
}
