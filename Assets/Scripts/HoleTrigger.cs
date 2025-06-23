using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall"))
        {
            Debug.Log("Ball in the hole!");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
            }

            // Optional: Snap it into place for effect
            other.transform.position = transform.position + Vector3.down * 0.1f;
        }
    }
}
