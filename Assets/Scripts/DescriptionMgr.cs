using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DescriptionMgr : MonoBehaviour
{

    [SerializeField] string nextSceneName = "Stage1";
    public void OnClick_TouchPanel()
    {
        GetComponent<Animator>().SetTrigger("NextScene");
    }

    // Animation Event In "Scene4"
    public void LoadToStage1()
    {
        StartCoroutine(LoaderCoroutine());
    }

    IEnumerator LoaderCoroutine()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            if(asyncOperation.progress >= 0.9f) asyncOperation.allowSceneActivation = true;
            yield return null;
        }
    }
}
