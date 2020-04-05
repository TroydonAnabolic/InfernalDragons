using UnityEngine;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]  // automatically places a health component object on any object that has a combat target component
    public class CombatTarget : MonoBehaviour
    {

    }
}
