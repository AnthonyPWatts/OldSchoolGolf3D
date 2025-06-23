using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private BallController ball;

    private bool hasHit = false;

    public void TakeShot(float power, float loftAngle = 35f)
    {
        if (hasHit || ball == null)
            return;

        Vector3 direction = Quaternion.Euler(-loftAngle, 0f, 0f) * Vector3.forward;
        ball.Hit(direction.normalized, power);
        hasHit = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeShot(12.5f); // TEMP: will be replaced by club + power bar later
        }
    }
}
