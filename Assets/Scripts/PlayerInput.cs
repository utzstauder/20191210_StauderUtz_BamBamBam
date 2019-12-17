using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    IInputReceiver[] inputReceivers;

    private void OnEnable()
    {
        inputReceivers = GetComponentsInChildren<IInputReceiver>();
    }

    void Update()
    {
        foreach (var inputReceiver in inputReceivers)
        {
            if (Input.GetButtonDown("Jump"))
            {
                inputReceiver.OnFireDown();
            }

            inputReceiver.HInput = Input.GetAxis("Horizontal");
            inputReceiver.VInput = Input.GetAxis("Vertical");
        }
    }
}
