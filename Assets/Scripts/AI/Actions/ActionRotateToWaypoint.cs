using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionRotateToWaypoint : Action
{
    public override void Act(StateController controller)
    {

        Vector3 distanceVector = controller.CurrentWaypoint.position - controller.transform.position;

        Vector3 cross = Vector3.Cross(controller.transform.forward, distanceVector);
        // Debug.Log(cross.y);

        // rotate around y-axis
        for (int i = 0; i < controller.InputReceivers.Length; i++)
        {
            if (Mathf.Abs(cross.y) < 0.1f)
            {
                controller.InputReceivers[i].HInput = 0;
            }
            else
            {
                controller.InputReceivers[i].HInput = Mathf.Sign(cross.y);
            }
        }
    }
}
