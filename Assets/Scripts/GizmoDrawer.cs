using UnityEngine;

[ExecuteAlways]
public class GizmoDrawer : MonoBehaviour
{
    public float length = 0.5f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * length;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(end, 0.02f);
    }
}
