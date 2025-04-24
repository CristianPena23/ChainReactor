using UnityEngine;
using System.Collections.Generic;

public class BondManagerCilindro : MonoBehaviour
{
    public GameObject bondCylinderPrefab;
    public float thickness = 0.05f;
    public float doubleBondOffset = 0.05f;

    private List<GameObject> enlacesInstanciados = new List<GameObject>();

    public void GenerateAllBondCylinders()
    {
        ClearAll();

        var allLinkPoints = Object.FindObjectsByType<LinkPoint>(FindObjectsSortMode.None);

        foreach (var punto in allLinkPoints)
        {
            if (punto.linkedTo != null && punto.gameObject.GetInstanceID() < punto.linkedTo.gameObject.GetInstanceID())
            {
                if (punto.isDoubleBond)
                {
                    CreateCilindro(punto.transform.position + Vector3.right * doubleBondOffset, punto.linkedTo.transform.position + Vector3.right * doubleBondOffset);
                    CreateCilindro(punto.transform.position - Vector3.right * doubleBondOffset, punto.linkedTo.transform.position - Vector3.right * doubleBondOffset);
                }
                else
                {
                    CreateCilindro(punto.transform.position, punto.linkedTo.transform.position);
                }
            }
        }
    }

    void CreateCilindro(Vector3 start, Vector3 end)
    {
        GameObject cilindro = Instantiate(bondCylinderPrefab);
        cilindro.transform.position = (start + end) / 2f;

        Vector3 dir = end - start;
        cilindro.transform.up = dir.normalized;
        cilindro.transform.localScale = new Vector3(thickness, dir.magnitude / 2f, thickness);

        enlacesInstanciados.Add(cilindro);
    }

    void ClearAll()
    {
        foreach (GameObject e in enlacesInstanciados)
        {
            if (e != null) Destroy(e);
        }
        enlacesInstanciados.Clear();
    }
}

