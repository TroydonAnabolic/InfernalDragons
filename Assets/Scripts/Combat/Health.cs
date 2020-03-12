using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        [SerlTransform target;


        public void TakeDamage(float damage)
        {
            // take the higher of either 0 or health if it goes under damage
            health = Mathf.Max(health - damage, 0);
            print(health);

            // if my char attacks the damage is added
            if()
        }
    }
}
