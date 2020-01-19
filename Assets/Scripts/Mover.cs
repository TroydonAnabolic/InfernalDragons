using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;
    void Update()
    {
        // change the destination for the navmesh agent to the target position. (e.g use player to go to target)
        GetComponent<NavMeshAgent>().destination = target.position;
    }
}
