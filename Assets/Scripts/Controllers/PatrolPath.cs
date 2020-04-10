using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        const float wayPointRadius = 0.3f;
        // loops all child elements
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform currentChild = transform.GetChild(i);

            Gizmos.DrawSphere(currentChild.position, wayPointRadius);
        }
    }
}
