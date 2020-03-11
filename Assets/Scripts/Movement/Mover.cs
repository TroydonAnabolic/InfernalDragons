using RPG.Combat;
using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        void Start()
        {
            // assigns the vairable to the position the navmesh agent it is attached to
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            // character movement animator
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            // this method calls movement but cancels fighting all the time
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        // gets the destination point parsed in and assigns it to the object with the navmesh
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            // enable movement again
            navMeshAgent.isStopped = false;
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity; // gets global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); // transforms global to local velocity (this is done to grab local cords and adjust it so animate velocity syncs)
            float speed = localVelocity.z; // use to update animator for the z direction, as this is the plane direction
            GetComponent<Animator>().SetFloat("forwardSpeed", speed); // creates a float value for the forward speed for the animation
        }

        // stops the movement of the navmesh
        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
    }
}