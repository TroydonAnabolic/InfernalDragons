using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Controllers;
using RPG.Movement;

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
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }

        }

        public void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // gets information from a ray to screen point aka mouseposition
            RaycastHit hit; // get information back from raycast
            bool hasHit = Physics.Raycast(ray, out hit); // determine if we received a hit location

            // if we hit something move to the point we hit
            if (hasHit)
                GetComponent<Mover>().MoveTo(hit.point);
        }
    }
}