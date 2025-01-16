using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    [SerializeField] LayerMask _interactableMask;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision Entered with {collision.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        int layerFlag = 1 << other.gameObject.layer;

        if ((layerFlag & _interactableMask) > 0)
        {
            Debug.Log("Interaction...");
        }

        //if (other.gameObject.tag == "Interactable")
        //{
        //    Debug.Log("Interaction...");
        //}
        //
        //Debug.Log($"Trigger Entered with {other.gameObject.name}");
    }
}
