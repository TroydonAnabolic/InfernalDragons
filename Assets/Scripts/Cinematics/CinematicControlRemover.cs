using System;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    class CinematicControlRemover : MonoBehaviour
    {
        void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;

        }

        private void EnableControl(PlayableDirector obj)
        {
            print("Enabled Control");
        }

        private void DisableControl(PlayableDirector obj)
        {
            print("Disabled Control");
        }
    }
}
