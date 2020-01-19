using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float timer;
    public bool isAI;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        // if its not an AI we make this obstacle move like this
        if (!isAI)
        {
            if (timer >= 0)
            {
                transform.position += Vector3.right * Time.deltaTime*1.5f;
            }
            else transform.position += Vector3.right * 0; // stop moving
        }
        else // if it is an AI then we move
        {
            if (timer <= 0)
            {
                transform.position = new Vector3(24, 1.5f, -1.45f); // teleport to hiding spot after a certain time
            }
        }
    }
}
