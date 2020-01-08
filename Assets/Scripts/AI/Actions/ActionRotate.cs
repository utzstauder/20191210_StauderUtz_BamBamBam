using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionRotate : Action
{
    public override void Act(StateController controller)
    {
        // rotate around y-axis
        for (int i = 0; i < controller.InputReceivers.Length; i++)
        {
            controller.InputReceivers[i].HInput = 1;
        }
    }
}
