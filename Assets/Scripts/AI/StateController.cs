using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(State targetState)
    {
        if (currentState != targetState)
        {
            currentState = targetState;
        }
    }
}
