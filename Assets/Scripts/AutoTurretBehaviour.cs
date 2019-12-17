using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurretBehaviour : MonoBehaviour
{
    IInputReceiver[] inputReceivers;

    float timer = 0;

    public LayerMask targetLayerMask;
    public float scanDistance = 5f;
    public float coolDown = 1f;

    private void OnEnable()
    {
        inputReceivers = GetComponentsInChildren<IInputReceiver>();
    }

    private void Update()
    {
        if (timer < coolDown)
        {
            timer += Time.deltaTime;
        } else
        {
            if (Physics.Raycast(
                origin: transform.position,
                direction: transform.forward,
                hitInfo: out RaycastHit hitInfo,
                maxDistance: scanDistance,
                layerMask: targetLayerMask,
                queryTriggerInteraction: QueryTriggerInteraction.Ignore)
                )
            {
                foreach (var inputReceiver in inputReceivers)
                {
                    inputReceiver.OnFireDown();
                }

                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(
            from: transform.position,
            direction: transform.forward * scanDistance
            );
    }
}
