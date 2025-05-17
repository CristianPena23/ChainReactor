using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BASEDEDATOS : MonoBehaviour
{
    [SerializeField] private List<pregun> m_preguntaslist = null;
    private List<pregun> m_backup = null;

    private void Awake()
    {
        m_backup = m_preguntaslist;
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
        m_preguntaslist = m_backup;
    }
}
