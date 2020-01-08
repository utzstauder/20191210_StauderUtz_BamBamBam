using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionShoot : Action
{
    public override void Act(StateController controller)
    {
        if (controller.Timer >= controller.data.coolDown)
        {
            for (int i = 0; i < controller.InputReceivers.Length; i++)
            {
                controller.InputReceivers[i].OnFireDown();
            }

            controller.ResetTimer();
        }

    }
}
