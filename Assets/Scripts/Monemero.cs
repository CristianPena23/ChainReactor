using UnityEngine;

public class Monemero : MonoBehaviour
{
    public bool isPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Recoger recoger = other.GetComponentInParent<Recoger>();
            if (recoger != null)
            {
                recoger.ObjectToPickUp = this.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInParent<Recoger>().ObjectToPickUp = null;
        }
    }

}
