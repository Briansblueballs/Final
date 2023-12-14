using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backNforth : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentwaypoint = 0;
    [SerializeField] float speed = 10;

    void Start()
    {
    }

    void Update()
    {//we check what checkpoint we move to. when we get to close we switch to the next waypoint
        if (Vector3.Distance(transform.position, waypoints[currentwaypoint].transform.position) < .1f)
        {
            currentwaypoint++;
            if (currentwaypoint >= waypoints.Length)
            {
                currentwaypoint = 0;
            }
        }
        //makes the gameobject move towards our waypoints
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentwaypoint].transform.position, speed * Time.deltaTime);
    }
}