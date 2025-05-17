using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class QUIZ_UI : MonoBehaviour
{
    [SerializeField] private Text m_pregunta =null;
    [SerializeField] private List<OPCIONBUTTON> m_buttonList = null;

    public void Construct(pregun q , Action<OPCIONBUTTON> callback )
    {
        m_pregunta.text = q.text;
        for(int n=0; n<m_buttonList.Count ; n++)
        {
            m_buttonList[n].Construct(q.opcion[n], callback);
        }
    }
}
