using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision Entered with {collision.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Entered with {other.gameObject.name}");
    }
}
