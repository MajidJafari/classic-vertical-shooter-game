using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            State.Manager.Instance.GoToNextState(State.States.GamePlay);
        }
    }
}
