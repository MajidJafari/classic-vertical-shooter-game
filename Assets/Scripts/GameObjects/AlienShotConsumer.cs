using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShotConsumer : Pool.Consumer
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.FloorToInt(Random.value * 1000.0f) % 900 == 0)
        {
            Consume<AlienShot>(new Vector3(transform.position.x,
                transform.position.y,
                0.5f));
        }
    }
}
