using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DecisionTargetInSight : Decision
{
    public override bool Decide(StateController controller)
    {
        // scan for targets
        if (Physics.Raycast(
                origin: controller.transform.position,
                direction: controller.transform.forward,
                hitInfo: out RaycastHit hitInfo,
                maxDistance: controller.data.scanDistance,
                layerMask: controller.data.targetLayerMask,
                queryTriggerInteraction: QueryTriggerInteraction.Ignore)
            )
        {
            return true;
        }

        return false;
    }
}
