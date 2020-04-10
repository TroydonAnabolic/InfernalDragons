using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;
using UnityEngine.AI;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 5f;
        Mover mover;
        Fighter fighter;
        GameObject player;
        Health health;
        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;

        private void Start()
        {
            guardPosition = transform.position;
            mover = GetComponent<Mover>();
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastSawPlayer += Time.deltaTime;

            if (!health.isDead())
            {
                if (AttackPlayer()) return; // if this is true we perform the action and then return, waiting for the next action to perform
                if (Suspicion()) return;
                if (GuardBehaviour()) return;
            }
        }

        private bool AttackPlayer()
        {
            // if we are in distance we chase and attack player, while he is alive
            if (InAttackRange() && fighter.CanAttack(player))
            {
                fighter.Attack(player.gameObject);
                timeSinceLastSawPlayer = 0;    // each time we see the player we reset suspicion counter
                return true;
            }
            return false;
        }

        // method to leave AI standing for 5 seconds, by cancelling all it's current actions
        private bool Suspicion()
        {
            if (!InAttackRange() && timeSinceLastSawPlayer < suspicionTime)
            {
                // stop movement and reset the time since we last saw player
                GetComponent<ActionScheduler>().CancelAction();     // disables all current action
                return true;
            }
            return false;
        }

        // if we are not within distance we return to our position, after 5 seconds have passed for suspicion to go
        private bool GuardBehaviour()
        {
            if (!InAttackRange() && timeSinceLastSawPlayer >= suspicionTime)
            {
                mover.StartMoveAction(guardPosition);
                return true;
            }
            return false;
        }

        // Evaluates to a true statement when distance from enemy to the palyer is less than chase distance
        private bool InAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer < chaseDistance;
        }

        // method called by Unity to call when we have character selected
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;      // draw gizmos in this method as blue
            Gizmos.DrawWireSphere(transform.position, chaseDistance);       // draw sphere from current position of object, with radius of chase distance
        }
    }
}