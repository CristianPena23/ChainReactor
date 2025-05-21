using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, -5);
    [Range(0, 1)] public float lerpValue = 0.1f;
    public float sensibilidad = 2f;

    private Transform target;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("❌ No se encontró un objeto con el tag 'Player'. Asegúrate de que el Player tenga el tag asignado.");
        }
    }

    void Update()
    {
        if (target == null) return;

        // Movimiento de cámara con interpolación
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);

        // Rotación del offset con el mouse
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        // La cámara mira al jugador
        transform.LookAt(target);
    }
}
