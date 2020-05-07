using UnityEngine;
using RPG.Movement;
using RPG.Core;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweemAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;
        Animator animator;

        Health target;
        float timeBetweenLastAttack = Mathf.Infinity;
        private void Start()
        {
        }

        private void Update()
        {
            animator = GetComponent<Animator>();

            timeBetweenLastAttack += Time.deltaTime;

            // make sure only trigger when enough time elapsed and reset time since alst attack

            if (target == null)
            {
                return;
            }
            // if target dies, we null it and then return for the next action
            if (target.isDead())
            {
                // target = null;
                return;
            }
            // TODO: Implement cancel attack so we can implement destroy game object, and not get stuck with no target
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position, 1f);
            }
            else
            {
                // uses movers cancel method implementation instead to stop moving
                GetComponent<Mover>().Cancel();
                // if the time since we last attacked is more or equal since the last attack, we play the attack animation
                // if we can attack attack animation
                  AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);     // look at the transform as soon as we are attacking

            if (timeBetweenLastAttack >= timeBetweemAttacks)
            {
                TriggerAttack();
                timeBetweenLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            // trigger the attack animation each time the time between last attack is greater or equal to 0
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
        }

        // Animation event
        void Hit()
        {
            // take health off each time the hit event is finished
            if (target != null) target.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        // add parameter to match the target as the combat target from player controller
        // This method allows us to click on an enemy behind a dead enemy
        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = GetComponent<Health>();
            return targetToTest != null && !targetToTest.isDead();      // returns true when this code block evaluates to true
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            target = null;
            StopAttack();
        }

        private void StopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }

        // returns true if the target exists and is alive

    }
}