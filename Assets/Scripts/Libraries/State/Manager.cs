using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace State
{
    public class Manager : MonoBehaviour
    {
        private bool loading = false;

        private static Manager _instance;

        public static Manager Instance
        {
            get
            {
                return _instance;
            }
        }

        public States initialState;

        private static States currentState;

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy (gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(this);
            SetScene (initialState);
        }

        public void GoToNextState(States nextState)
        {
            if (!loading)
            {
                this.loading = true;
                SetScene (nextState);

            }
        }

        private void SetScene(States state)
        {
            Manager.currentState = state;
            StartCoroutine(LoadScene(state));
        }

        private IEnumerator LoadScene(States state)
        {
            var asyncScene =
                SceneManager
                    .LoadSceneAsync((int) state, @LoadSceneMode.Single);

            //Wait until we are done loading the scene
            while (!asyncScene.isDone)
            {
                Debug
                    .Log("Loading scene " +
                    state +
                    ": " +
                    Mathf.FloorToInt(asyncScene.progress * 100) +
                    "%");
                yield return null;
            }

            
            this.loading = false;
        }
    }
}
