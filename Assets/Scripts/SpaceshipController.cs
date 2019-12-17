using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour, IInputReceiver
{
    Rigidbody rb;

    float hInput, vInput;

    public float thrusterForce = 10f;
    public float sidewaysThrusterForce = 1f;

    public float HInput { set { hInput = value; } }
    public float VInput { set { vInput = value; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // ship acceleration
        rb.AddForce(transform.forward * vInput * thrusterForce, ForceMode.Acceleration);

        // ship rotation
        rb.AddTorque(transform.up * hInput * sidewaysThrusterForce, ForceMode.Acceleration);
    }

    public void OnFireDown(){}
}
