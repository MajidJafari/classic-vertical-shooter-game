using System;
using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Pool
{
    public class Manager : MonoBehaviour
    {
        private Manager _instance;

        public List<Config> poolConfig;

        private static Dictionary<ObjectTypes, Producer<Object>>
            producers = new Dictionary<ObjectTypes, Producer<Object>>();

        public static Element Pull<Element>(ObjectTypes type, Vector3 position)
            where Element : Object
        {
            if (Manager.producers.ContainsKey(type))
            {
                var handler = producers[type];
                return handler.Pull(position) as Element;
            }
            throw new InvalidObjectType(type);
        }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy (gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad (gameObject);
            Initialize();
        }

        private void Initialize()
        {
            foreach (Config config in poolConfig)
            {
                var (objectType, @object, size, position) = config;
                if (!Manager.producers.ContainsKey(objectType))
                {
                    Debug
                        .Log("+++ Pool Object for " +
                        objectType +
                        " has been initialized. +++");
                    Manager
                        .producers
                        .Add(objectType,
                        new Producer<Object>(@object, size, position));
                }
            }
        }
    }
}
