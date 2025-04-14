using UnityEngine;

public class Pins : MonoBehaviour
{
    [Header("Fall Detection")]
    public float fallAngleThreshold = 45f;
    public float yPositionThreshold = -0.5f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    
    private bool isFallen = false;

    public bool IsFallen => isFallen;
    private float fallDetectionDelay = 1.5f; // Delay after Start
    private float timeSinceStart = 0f;
    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (timeSinceStart < fallDetectionDelay)
        {
            timeSinceStart += Time.deltaTime;
            return;
        }

        if (isFallen) return;

        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);

        if (tiltAngle > fallAngleThreshold || transform.position.y < yPositionThreshold)
        {
            isFallen = true;
            OnPinFallen();
        }
    }

    void OnPinFallen()
    {
        Debug.Log($"{gameObject.name} has fallen!");
        // Sound, animation
    }

    public void ResetPin()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        isFallen = false;
        
    }
}
