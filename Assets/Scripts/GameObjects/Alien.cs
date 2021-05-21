using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Pool.Object
{
    void OnCollisionEnter2D(Collision2D other)
    {
        var type = other.gameObject.GetComponent<Shot>()?.poolObjectType;
        if (type == Pool.ObjectTypes.Shot)
        {
            Push();
        }
    }

    public override Pool.Object ResetProps()
    {
        return this;
    }
}
