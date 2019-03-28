using UnityEngine;

public class ShipCollisionDectection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ICollider>()
            .TriggerCollision();
    }
}
