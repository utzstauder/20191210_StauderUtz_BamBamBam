using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DecisionTargetInSight : Decision
{
    public override bool Decide(StateController controller)
    {
        // TODO: scan for targets

        return false;
    }
}
