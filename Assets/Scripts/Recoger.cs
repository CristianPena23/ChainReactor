using UnityEngine;

public class Recoger : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    void Update()
    {
        // Lógica para recoger objetos
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<Monemero>().isPickable == true && PickedObject == null)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUpObject();
            }
        }
        // Lógica para soltar/enlazar objetos
        else if(PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Primero intenta enlazar el objeto
                if (!TryBondObject())
                {
                    // Si no se puede enlazar, simplemente lo suelta
                    DropObject();
                }
            }
        }
    }

    void PickUpObject()
    {
        PickedObject = ObjectToPickUp;
        PickedObject.GetComponent<Monemero>().isPickable = false;
        PickedObject.transform.SetParent(interactionZone);
        PickedObject.transform.position = interactionZone.position;
        PickedObject.GetComponent<Rigidbody>().useGravity = false;
        PickedObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    bool TryBondObject()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return false;

        MonomeroEnlace enlace = PickedObject.GetComponent<MonomeroEnlace>();
        if (enlace == null) return false;

        enlace.EnlazarAlJugador(player.transform);

        if (PickedObject.transform.parent == player.transform)
        {
            PickedObject = null;

            // 🎯 Generar enlaces visuales después de cada unión
            Object.FindFirstObjectByType<BondManagerCilindro>()?.GenerateAllBondCylinders();



            return true;
        }

        return false;
    }   


    void DropObject()
    {
        PickedObject.GetComponent<Monemero>().isPickable = true;
        PickedObject.transform.SetParent(null); 
        PickedObject.GetComponent<Rigidbody>().useGravity = true;
        PickedObject.GetComponent<Rigidbody>().isKinematic = false;
        PickedObject = null;
    }
}