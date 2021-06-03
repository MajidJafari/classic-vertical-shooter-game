using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShot : Pool.Object
{
    public delegate void HitShip();
    public static event HitShip hitShip;
    public float speed;

    public override Pool.Object ResetProps()
    {
        this.transform.rotation = Quaternion.identity;
        return this;
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y < -16)
        {
            Push();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Ship>())
        {
            Push();
            if(hitShip != null) {
                hitShip();
            }
        }
    }
}
