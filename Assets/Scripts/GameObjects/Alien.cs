using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Pool.Object
{
    public delegate void OnDeath();

    public static event OnDeath onDeath;

    void OnCollisionEnter2D(Collision2D other)
    {
        var type = other.gameObject.GetComponent<Shot>()?.poolObjectType;
        if (type == Pool.ObjectTypes.Shot)
        {
            if (onDeath != null)
            {
                onDeath();
            }
            Push();
        }
    }

    public override Pool.Object ResetProps()
    {
        return this;
    }
}
