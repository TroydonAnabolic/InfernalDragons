using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            if (InteractWithCombat()) return; // if this is true we perform the action and then return, waiting for the next action to perform
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            // gets an array of hits
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                // set it so only when the ray hits the target with the component COmbat Target then we set value to target on the ray
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                // if we have no target we continue
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
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
                    GetComponent<Mover>().StartMoveAction(hit.point);
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