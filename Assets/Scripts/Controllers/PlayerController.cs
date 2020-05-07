using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }
        private void Update()
        {
            // while we are not dead we can make these actions
            if (!health.isDead())
            {
                if (InteractWithCombat()) return; // if this is true we perform the action and then return, waiting for the next action to perform
                if (InteractWithMovement()) return;
            }
        }

        private bool InteractWithCombat()
        {
            // if we can attack then we may shoot rays
            // gets an array of hits of mouse
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                // keep trying to get the raycast hits until we have a valid and alive target
                CombatTarget target;
                // set it so only when the ray hits the target with the component COmbat Target then we set value to target on the ray
                target = hit.transform.GetComponent<CombatTarget>();

                if (target == null) { continue; }

                if (!GetComponent<Fighter>().CanAttack(target.gameObject)) // sets the game object of the target as the target
                {
                    continue;
                }

                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                    // else continue;
                }
                return true;
            }
            // do not interact with combat if we do not click on anything and target is not dead
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    // we always use the cancel move action on every movement
                    GetComponent<Mover>().StartMoveAction(hit.point, 1f);
                }
                return true;
            }
            return false;
        }

        // gets where the mouse points
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}