using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private float stopVelocityThreshold = 0.1f;
    private float stopAngularVelocityThreshold = 0.1f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public bool IsMoving => rb.linearVelocity.magnitude > stopVelocityThreshold || rb.angularVelocity.magnitude > stopAngularVelocityThreshold;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Optional helper if you want to reset the ball
    public void ResetBall()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
