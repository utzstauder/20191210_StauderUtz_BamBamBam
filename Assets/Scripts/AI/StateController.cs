using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    float timer = 0;
    public float Timer => timer;

    IInputReceiver[] inputReceivers;
    public IInputReceiver[] InputReceivers => inputReceivers;

    [SerializeField] Transform[] waypoints;
    public Transform[] Waypoints => waypoints;

    int currentWaypointIndex = 0;
    public int CurrentWaypointIndex
    {
        get => currentWaypointIndex;
        set
        {
            currentWaypointIndex = value;

            if (Waypoints == null) return;

            // wrap negative range
            while (currentWaypointIndex < 0)
            {
                currentWaypointIndex += Waypoints.Length;
            }
            
            // wrap positive range
            while (currentWaypointIndex >= Waypoints.Length)
            {
                currentWaypointIndex -= Waypoints.Length;
            }
        }
    }
    public Transform CurrentWaypoint => waypoints[currentWaypointIndex];

    [SerializeField]
    private float waypointDistanceThreshold = 1f;
    public float WaypointDistanceThreshold => waypointDistanceThreshold;

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

    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        Gizmos.color = Color.red;

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (i == waypoints.Length - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            } else
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }

            Gizmos.DrawWireSphere(waypoints[i].position, WaypointDistanceThreshold);
        }
    }
}
