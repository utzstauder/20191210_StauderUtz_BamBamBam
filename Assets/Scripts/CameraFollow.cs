using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * smoothSpeed);
    }
}
