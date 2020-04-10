using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        [SerializeField] float timer = 0f;
        [SerializeField] bool hasDied = false;

        void Update()
        {
             
            // if the player has died and the death trigger animation was set off, we turn the trigger off
            if (hasDied)
            {

                // start the time counter
                timer += (Time.deltaTime);
                // stop the death animation once we reach 2 seconds
                if (timer >= 10)
                {
                    // TODO: destroy object once it is dead for more than 60 seconds
                    // Destroy(gameObject);
                }
            }
        }
        public bool isDead()
        {
            return hasDied;
        }

        public void TakeDamage(float damage)
        {
            // take the higher of either 0 or healthPoints if it goes under damage, avoids getting health less than 0
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(healthPoints);

            if (healthPoints == 0) // we do not need to say <= because when we grab health points we already ensured it
            {
                DeathBehaviour();
            }
        }

        // trigger death animation
        private void DeathBehaviour()
        {
            // only trigger when he is not dead
            if (hasDied) return;
            hasDied = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelAction();     // disables all current action
        }
    }
}
