using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

public class WaveManager : Pool.Consumer
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        for (int j = 0; j < 6; j++)
        {
            Consume<Alien>(new Vector3((i - 7) * 0.5f, (j - 2) * 0.8f, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
