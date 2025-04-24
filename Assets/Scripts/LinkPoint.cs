using UnityEngine;

public class LinkPoint : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isCarbonBond = true;
    public bool isDoubleBond = false;
    public LinkPoint linkedTo; // NUEVO: quién está enlazado a este punto
    
    // Visualización del punto
    void OnDrawGizmos()
    {
        Gizmos.color = isCarbonBond ? Color.black : Color.white;
        Gizmos.DrawSphere(transform.position, 0.05f);
        if(isDoubleBond) 
        {
            Gizmos.DrawWireSphere(transform.position, 0.07f);
        }
    }
}

