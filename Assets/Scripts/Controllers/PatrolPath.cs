using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            const float wayPointRadius = 0.3f;
            // loops all child elements
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), wayPointRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }

        public int GetNextIndex(int i)
        {
            if (i == (transform.childCount - 1)) return 0;    // when we reacht the final way point we want j to be 0 instead of more than 4 because we cannot return to a point higher than 4th element, and we have to return to the first element
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
