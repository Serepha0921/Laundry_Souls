using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Slider slider;

    public int SceneLevel;

    AsyncOperation async;

    private void Start()
    {
        loadingscene();
    }

    public void loadingscene()
    {
        StartCoroutine(loadingscenes(SceneLevel));
    }

    IEnumerator loadingscenes(int lvl)
    {
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
