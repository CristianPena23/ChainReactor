using System.Collections.Generic;
using UnityEngine;

public class MonomeroEnlace : MonoBehaviour
{
    [Header("Configuración de Enlace")]
    public Transform bondPoint;
    public string targetTag = "Player";
    public bool isCarbon = true;

    [Header("Configuración Etileno")]
    public bool canFormDoubleBond = false;
    public int maxBonds = 4;

    private Transform linkedPoint;

    void EstablishBond(LinkPoint punto, Transform player)
    {
        // Ajuste de posición y rotación
        Vector3 offset = bondPoint.position - transform.position;
        transform.position = punto.transform.position - offset;

        if (punto.isDoubleBond)
        {
            Vector3 direccion = player.position - transform.position;
            if (direccion != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direccion);
        }

        // Parenting y física
        transform.SetParent(player);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // Marcar el punto objetivo como ocupado
        punto.isOccupied = true;

        // Buscar el LinkPoint propio más cercano válido
        LinkPoint myPoint = null;
        float minDist = Mathf.Infinity;

        foreach (LinkPoint lp in GetComponentsInChildren<LinkPoint>())
        {
            if (!lp.isOccupied && lp.isCarbonBond == this.isCarbon && !lp.isDoubleBond)
            {
                float dist = Vector3.Distance(lp.transform.position, punto.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    myPoint = lp;
                }
            }
        }

        if (myPoint != null)
        {
            punto.isOccupied = true;
            myPoint.isOccupied = true;

            punto.linkedTo = myPoint;
            myPoint.linkedTo = punto;

            Debug.Log("✅ Enlace creado entre " + punto.name + " y " + myPoint.name);
        }
        else
        {
            Debug.LogWarning("❌ No se encontró un LinkPoint válido en este monómero para conectar con " + punto.name);
        }

        linkedPoint = punto.transform;
    }

    public void EnlazarAlJugador(Transform player)
    {
        LinkPoint[] puntos = player.GetComponentsInChildren<LinkPoint>();
        int bondsFormed = 0;

        foreach (LinkPoint punto in puntos)
        {
            bool bondValid = (!punto.isOccupied) && 
                             (punto.isCarbonBond == this.isCarbon) && 
                             (!punto.isDoubleBond || this.canFormDoubleBond);

            if (bondValid && bondsFormed < maxBonds)
            {
                EstablishBond(punto, player);
                bondsFormed++;

                if (!isCarbon) break;
                if (punto.isDoubleBond) maxBonds = 1;
            }
        }
    }
}
