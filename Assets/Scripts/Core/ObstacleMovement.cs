using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Change the log
namespace RPG.Controllers.Core
{
    // class to randomly move object
    public class ObstacleMovement : MonoBehaviour
    {
        float timer;
        public bool isAI;

        // Start is called before the first frame update
        void Start()
        {
            timer = 5f;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            timer -= Time.deltaTime;

            // if its not an AI we make this obstacle move like this
            if (!isAI)
            {
                if (timer >= 0)
                {
                    // transform.position is the objects position. += vector 3 is the movement speed towards the right, this is continouosly updated as tune passes until we reach 5f
                    transform.position += Vector3.right * Time.deltaTime * 1.5f;
                }
                else transform.position += Vector3.right * 0; // stop moving
            }
            else // if it is an AI then we move
            {
                if (timer <= 0)
                {
                    transform.position = new Vector3(24, 1.5f, -1.45f); // teleport target to hiding spot after a certain time
                }
            }
        }
    }
}