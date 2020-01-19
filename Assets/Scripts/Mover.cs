using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;
    Ray lastRay;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor(); 
        }
        // draw the ray

        // change the destination for the navmesh agent to the target position. (e.g use player to go to target)

    }

    public void MoveToCursor()
    {
        Physics.Raycast()
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        GetComponent<NavMeshAgent>().destination = target.position;

    }
}
