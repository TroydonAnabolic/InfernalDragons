using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Controllers;
using RPG.Movement;
using System;
using RPG.Combat;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InteractWithCombat()) return; // if we are interacting with combat we skip movement and attack
            if (InteractWithMovement()) return; // we can move move, if not print nothing to do
            print("Nothing to do");
        }

        private bool InteractWithCombat()
        {
            // method for hitting only select items to attack so we can ignore environment
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                // find results with combat target, use get component, check it has combat target
                // call attack with fighter
                CombatTarget target = hit.transform.GetComponent<CombatTarget>(); // gets the current location of the target
                if (target == null) continue; // if taget is not clicked check next item on loop
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target); // attack target
                }
                    return true; // if we hover over target we stop movement
            }
            return false;
        }

        public bool InteractWithMovement()
        {
            RaycastHit hit; // get information back from raycast
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); // gets the mouse position and send out the hit location, once hit will be true

            // if the mouse received ray hit
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    // if we hit something move to the point we hit(we use  GetComponent<Mover>().MoveTo to access the mover's class's MoveTo method)
                    // then elect hit.point to send the cords of where to move to
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true; // return true if light has hit
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            // gets information from a ray to screen point aka mouseposition
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}