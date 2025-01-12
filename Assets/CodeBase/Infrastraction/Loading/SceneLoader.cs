using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastraction.Loading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string nameScene, Action onLoader = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(nameScene, onLoader));
        }

        private IEnumerator LoadScene(string nextScene, Action onLoader = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoader?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            onLoader?.Invoke();
        }
    }
}