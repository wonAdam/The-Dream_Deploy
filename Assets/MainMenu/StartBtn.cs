using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    [SerializeField] Image FadeinOut;
    public void OnClick_StartBtn(){
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad(){
        SaveData saveData = SaveMgr.LoadData();
        string sceneName = "Prologue";

        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;
        FadeinOut.gameObject.SetActive(true);
        FadeinOut.DOFade(1f, 2f);
        yield return new WaitForSeconds(2f);

        while(true){
            yield return null;
            Debug.Log(asyncOperation.progress);

            if(asyncOperation.progress >= 0.9f){
                Debug.Log("0.9 Done");
                asyncOperation.allowSceneActivation = true;
                break;
            }
        }


    }



}
