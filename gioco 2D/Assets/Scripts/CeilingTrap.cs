using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int CurrentWaypoint = 0;
    [SerializeField] private float Speed = 10f;


    private void Update()
    {
        if(Vector2.Distance(Waypoints[CurrentWaypoint].transform.position, transform.position) < 0.1f)
        {
            CurrentWaypoint++;
            if(CurrentWaypoint >= Waypoints.Length)
            {
                CurrentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[CurrentWaypoint].transform.position, Time.deltaTime * Speed);
    }
}
