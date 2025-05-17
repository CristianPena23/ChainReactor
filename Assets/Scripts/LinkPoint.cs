using UnityEngine;

public class LinkPoint : MonoBehaviour
{
    public bool isOccupied = false;
    public bool isCarbonBond = false;
    public bool isDoubleBond = false;
    public LinkPoint linkedTo;
    void OnDrawGizmos()
    {
        Gizmos.color = isCarbonBond ? Color.cyan : Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

