using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        Mover mover;
        void Start()
        {
            mover = GetComponent<Mover>();
        }
        void Update()
        {
            // if there is no target we do not try to do any attack or attack evaluation
            if (target == null) return;

            // if target is not null and not in range we move to it
            if ( !IsInRange())
            {
                mover.MoveTo(target.position);
            }
            // if target is in range and exists we stop moving
            else
            {
                mover.Stop();
            }

        }

        private bool IsInRange()
        {
            // if the target distance is in range when under weapon range
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            Debug.Log("Take that you demon!");
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
