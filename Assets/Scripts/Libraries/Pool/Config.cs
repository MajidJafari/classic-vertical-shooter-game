using System;
using UnityEngine;

namespace Pool
{
    [Serializable]
    public struct Config
    {
        public ObjectTypes objectType;

        public GameObject @object;

        public int size;

        public Vector3 position;

        public void Deconstruct(
            out ObjectTypes objectType,
            out Pool.Object @object,
            out int size,
            out Vector3 position
        )
        {
            objectType = this.objectType;
            @object = this.@object.GetComponent<Pool.Object>();
            size = this.size;
            position = this.position;
        }
    }
}
