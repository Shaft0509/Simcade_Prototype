using UnityEngine;

public class CarPhysics : MonoBehaviour
{
    [Header("Car Movement")]
    public float acceleration = 5000f;
    public float turnSpeed = 120f;
    public float boostMultiplier = 2f;
    public float frontAxleOffset = 1.5f; // Distance from center to front wheels

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        // Movement input
        float move = Input.GetAxis("Vertical");    // W/S
        float turn = Input.GetAxis("Horizontal");  // A/D

        // Acceleration boost
        float currentAcceleration = acceleration;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            currentAcceleration *= boostMultiplier;

        // Apply forward/backward force
        rb.AddForce(transform.forward * move * currentAcceleration, ForceMode.Force);

        // Rotate around front axle
        if (move != 0f && turn != 0f)
        {
            Vector3 pivotPoint = transform.position + transform.forward * frontAxleOffset;
            transform.RotateAround(pivotPoint, Vector3.up, turn * turnSpeed * Time.fixedDeltaTime);
        }
    }
}
