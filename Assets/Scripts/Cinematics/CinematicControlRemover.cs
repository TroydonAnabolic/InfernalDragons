using RPG.Control;
using RPG.Core;
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    class CinematicControlRemover : MonoBehaviour
    {
        GameObject player;
        void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        private void EnableControl(PlayableDirector obj)
        {
            player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerController>().enabled = true; // player.GetComponent is what we use to grab components on another object
        }
        private void DisableControl(PlayableDirector obj)
        {
            player = GameObject.FindWithTag("Player");
            player.GetComponent<ActionScheduler>().CancelAction();
            player.GetComponent<PlayerController>().enabled = false;
        }
    }
}
