using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void Load(string name, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
    }

    private IEnumerator LoadScene(string nameScene, Action onLoaded)
    {
        var waitNextScene = SceneManager.LoadSceneAsync(nameScene);

        while (!waitNextScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}
