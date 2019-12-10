using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour
{
    Rigidbody rb;

    float hInput, vInput;

    public float thrusterForce = 10f;
    public float sidewaysThrusterForce = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // ship acceleration
        rb.AddForce(transform.forward * vInput * thrusterForce, ForceMode.Acceleration);

        // ship rotation
        rb.AddTorque(transform.up * hInput * sidewaysThrusterForce, ForceMode.Acceleration);
    }
}
