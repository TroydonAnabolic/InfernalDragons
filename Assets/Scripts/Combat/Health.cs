using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        [SerializeField] GameObject gameObject;
        float timer;


        void Update()
        {
            // time death
            timer -= Time.deltaTime;
        }

        public void TakeDamage(float damage)
        {
           // if(GetComponent<Fighter>().Attack(target))
            // take the higher of either 0 or health if it goes under damage

            health = Mathf.Max(health - damage, 0);
            print(health);

            if (health <= 0)
            {
                DeathBehaviour();
                timer = 2f;
               // if (timer <= 0) Destroy(gameObject);
            }
        }

        // trigger death animation
        private void DeathBehaviour()
        {
            GetComponent<Animator>().SetTrigger("die");

        }

        void Death()
        {

        }
    }
}
