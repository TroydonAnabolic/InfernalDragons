using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            player = GameObject.FindWithTag("Player");
            // GameObject enemy = GameObject.FindWithTag
            if (DistanceToPlayer())
            {
                print(this.name + " is chasing " + player);
            }
        }

        // Evaluates to a true statement when distance from enemy to the palyer is less than chase distance
        private bool DistanceToPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position) < chaseDistance;
        }
    }
}