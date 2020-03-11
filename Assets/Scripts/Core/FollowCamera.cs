using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core

{
    public class FollowCamera : MonoBehaviour
    {
        // this is a position variable(which will be assigned to the variable that needs to be the target)
        [SerializeField] Transform target;

        // using late update to avoid glitching screen, so the camera updates after the animation is done
        void LateUpdate()
        {
            // make the object that has the script attached's position the same as target
            transform.position = target.position;
        }
    }
}