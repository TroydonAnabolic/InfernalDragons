using RPG.Controllers;
using System;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {

        public void Attack(CombatTarget target)
        {
            Debug.Log("Take that you demon!");
        }

        private Vector3 Vector3(double v1, int v2, int v3)
        {
            return Vector3(v1, v2, v3);
        }
    }
}
