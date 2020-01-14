using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionAccelerateToWaypoint : Action
{
    public override void Act(StateController controller)
    {
        float currentDistanceToWaypoint = Vector3.Distance(controller.transform.position, controller.CurrentWaypoint.position);
        
        for (int i = 0; i < controller.InputReceivers.Length; i++)
        {
            if (currentDistanceToWaypoint > controller.WaypointDistanceThreshold)
            {
                controller.InputReceivers[i].VInput = 1;
            } else
            {
                controller.InputReceivers[i].VInput = 0;
                controller.CurrentWaypointIndex++;
            }
        }
    }
}
