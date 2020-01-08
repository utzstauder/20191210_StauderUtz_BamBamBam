using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour, IInputReceiver
{
    Rigidbody rb;

    float hInput, vInput;

    public SpaceshipData data;

    public float ThrusterForce { get { return data.Acceleration; } }
    public float SidewaysThrusterForce { get { return data.RotationForce; } }

    public float HInput { set { hInput = value; } }
    public float VInput { set { vInput = value; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (data == null)
        {
            data = new SpaceshipData();
        }

        data.OutputData();
    }

    private void FixedUpdate()
    {
        // ship acceleration
        rb.AddForce(transform.forward * vInput * ThrusterForce, ForceMode.Acceleration);

        // ship rotation
        rb.AddTorque(transform.up * hInput * SidewaysThrusterForce, ForceMode.Acceleration);
    }

    public void OnFireDown(){}
}
