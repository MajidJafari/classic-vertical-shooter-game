using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : Pool.Object
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (transform.position.y > 6.0f)
        {
            Push();
        }
    }

    public override Pool.Object ResetProps()
    {
        this.transform.rotation = Quaternion.identity;
        return this;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var type = other.gameObject.GetComponent<Alien>()?.poolObjectType;
        if (type == Pool.ObjectTypes.Alien)
        {
            Push();
        }
    }
}
