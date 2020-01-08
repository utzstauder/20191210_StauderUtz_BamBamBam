using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpaceshipData : ScriptableObject
{
    [SerializeField]
    float acceleration = 10f;
    [SerializeField]
    float rotationForce = 10f;

    public float Acceleration => acceleration;
    public float RotationForce => rotationForce;

    public SpaceshipData()
    {
        Debug.Log("New SpaceshipData object created.");
    }

    public void OutputData()
    {
        Debug.Log(Acceleration + " | " + RotationForce);
    }
}
