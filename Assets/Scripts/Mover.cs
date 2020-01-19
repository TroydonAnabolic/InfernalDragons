using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;

    void Start()
    {
        // isAI = false;
    }
    void Update()
    {
        // if it is an AI we move to the destination
            // change the destination for the navmesh agent to the target position. (e.g use player to go to target)
            GetComponent<NavMeshAgent>().destination = target.position;
        
    }
}
