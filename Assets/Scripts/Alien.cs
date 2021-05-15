using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
public class Alien : Pool.Object
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool ShouldBePushed()
    {
        throw new System.NotImplementedException();
    }

    public override Pool.Object ResetProps() { 
        return this; 
    }

    public override ObjectTypes GetPoolObjectType() => Pool.ObjectTypes.Alien;
}
