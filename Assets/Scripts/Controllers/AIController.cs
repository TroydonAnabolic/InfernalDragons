using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        GameObject player;
        Health health;
        Vector3 originalPosition;

        private void Start()
        {
            originalPosition = transform.position;
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!health.isDead())
            {
                if (AttackPlayer()) return; // if this is true we perform the action and then return, waiting for the next action to perform
                if (ReturnToBase()) return;
            }
        }

        private bool AttackPlayer()
        {
            // if we are in distance we chase and attack player, while he is alive
            if (InAttackRaneOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player.gameObject);
                return true;
            }
            return false;
        }

        private bool ReturnToBase()
        {
            // if we are not within distance we return to our position at the start of the game
            if (!InAttackRaneOfPlayer())
            {
                GetComponent<Mover>().StartMoveAction(originalPosition);
                return true;
            }
            return false;
        }



        // Evaluates to a true statement when distance from enemy to the palyer is less than chase distance
        private bool InAttackRaneOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}