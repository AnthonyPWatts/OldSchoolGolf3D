using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 minOffset = new Vector3(0, 3, -4);
    public Vector3 maxOffset = new Vector3(0, 7, -12);
    public float maxBallSpeed = 10f;
    public float zoomSmooth = 3f;
    public float followSmooth = 5f;

    private Rigidbody targetRb;
    private Vector3 currentOffset;

    void Start()
    {
        currentOffset = minOffset;

        if (target != null)
            targetRb = target.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (target == null || targetRb == null) return;

        // 1. Use altitude (Y position of the ball) to determine zoom level
        float altitude = target.position.y;

        // Clamp altitude for smooth interpolation (e.g. between 0 and 10 units)
        float t = Mathf.Clamp01(altitude / 10f); // tweak 10f for sensitivity

        // 2. Interpolate between close and far offsets based on height
        Vector3 desiredOffset = Vector3.Lerp(minOffset, maxOffset, t);

        // 3. Smooth the offset change (damping)
        currentOffset = Vector3.Lerp(currentOffset, desiredOffset, zoomSmooth * Time.deltaTime);

        // 4. Update camera position
        Vector3 targetPosition = target.position + currentOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSmooth * Time.deltaTime);

        transform.LookAt(target);
    }

}
