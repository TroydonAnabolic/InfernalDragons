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

        Transform target;
        float timeBetweenLastAttack = 0;
        private void Update()
        {
            timeBetweenLastAttack += Time.deltaTime;

            // make sure only trigger when enough time elapsed and reset time since alst attack

            if (target == null)
            {
                return;
            }

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                // uses movers cancel method implementation instead
                GetComponent<Mover>().Cancel();
                // if the time since we last attacked is more or equal since the last attack, we play the attack animation
               
                    AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
        if (timeBetweenLastAttack >= timeBetweemAttacks)
        {
                // trigger the attack animation each time the time between last attack is greater or equal to 0
            GetComponent<Animator>().SetTrigger("attack");
                timeBetweenLastAttack = 0;
            }
        }


        // Animation event
        void Hit()
        {
            // take health off each time the hit event is finished
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
  
        }

        public void Cancel()
        {
            target = null;
        }


    }
}