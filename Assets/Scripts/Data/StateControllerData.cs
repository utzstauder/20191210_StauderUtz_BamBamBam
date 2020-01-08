using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StateControllerData : ScriptableObject
{
    public LayerMask targetLayerMask;
    public float scanDistance = 5f;
    public float coolDown = 1f;
}
