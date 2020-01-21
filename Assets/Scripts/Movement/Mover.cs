using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        void Start()
        {
        }
        void Update()
        {

            //if (Input.GetMouseButton(0))
            //{
            //    MoveToCursor(); 
            //}


            // character movement animator
            UpdateAnimator();

        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity; // gets global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); // transforms to local velocity
            float speed = localVelocity.z; // use to update animator for the z direction
            GetComponent<Animator>().SetFloat("forwardSpeed", speed); // creates a float value for the forward speed from the ani
        }
        // gets the nav mesh vector 3 destination point
        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }
    }
}