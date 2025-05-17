using UnityEngine;

public class BondManager : MonoBehaviour
{
    public static BondManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void GenerateAllBondLines()
    {
        // Nuevo método recomendado desde Unity 2023
        var allLinkPoints = Object.FindObjectsByType<LinkPoint>(FindObjectsSortMode.None);

        foreach (var punto in allLinkPoints)
        {
            // Evita dibujar dos veces el mismo enlace
            if (punto.linkedTo != null && punto.gameObject.GetInstanceID() < punto.linkedTo.gameObject.GetInstanceID())
            {
                DrawBondLine(punto, punto.linkedTo, punto.isDoubleBond);
            }
        }
    }

    void DrawBondLine(LinkPoint a, LinkPoint b, bool isDouble)
    {
        float offsetDist = isDouble ? 0.05f : 0f;
        Vector3 dir = (b.transform.position - a.transform.position).normalized;
        Vector3 perp = Vector3.Cross(dir, Vector3.up).normalized;

        for (int i = 0; i < (isDouble ? 2 : 1); i++)
        {
            GameObject lineObj = new GameObject("BondLine");
            LineRenderer lr = lineObj.AddComponent<LineRenderer>();
            lr.startWidth = 0.03f;
            lr.endWidth = 0.03f;

            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.material.color = Color.red; 

            Vector3 offset = (i == 0) ? perp * offsetDist : -perp * offsetDist;

            lr.positionCount = 2;
            lr.SetPosition(0, a.transform.position + offset);
            lr.SetPosition(1, b.transform.position + offset);

            // Opcional: hacer hijo de uno de los átomos para que se mueva con ellos
            lineObj.transform.SetParent(a.transform);
        }
    }
}
