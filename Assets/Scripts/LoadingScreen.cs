using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadBar;
    public Image barFill;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadingSceneAsync(sceneId));
    }

    IEnumerator LoadingSceneAsync(int sceneId)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneId);

        LoadBar.SetActive(true);

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            barFill.fillAmount = progress;
            yield return null;
        }
    }

}
