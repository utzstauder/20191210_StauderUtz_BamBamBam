using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    float timer = 0;
    public float Timer => timer;

    IInputReceiver[] inputReceivers;
    public IInputReceiver[] InputReceivers => inputReceivers;

    public State currentState;
    public StateControllerData data;

    private void OnEnable()
    {
        inputReceivers = GetComponentsInChildren<IInputReceiver>();
    }

    private void Update()
    {
        ResetInputs();

        currentState.UpdateState(this);

        timer += Time.deltaTime;
    }

    private void ResetInputs()
    {
        for (int i = 0; i < InputReceivers.Length; i++)
        {
            InputReceivers[i].HInput = 0;
            InputReceivers[i].VInput = 0;
        }
    }

    public void TransitionToState(State targetState)
    {
        if (currentState != targetState
            && targetState != null)
        {
            currentState = targetState;
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
