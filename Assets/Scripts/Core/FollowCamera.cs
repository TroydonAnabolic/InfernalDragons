using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core

{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        // using late update to avoid glitching screen
        void LateUpdate()
        {
            // make the targets position the same as target
            transform.position = target.position;
        }
    }
}