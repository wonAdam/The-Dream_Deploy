using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMgr : MonoBehaviour
{
    [SerializeField] Image FadeINOUT;
    private void Awake() {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn(){
        FadeINOUT.gameObject.SetActive(true);
        FadeINOUT.color = new Color(1f,1f,1f,1f);
        FadeINOUT.DOFade(0f, 2f);
        yield return new WaitForSeconds(2f);
        FadeINOUT.gameObject.SetActive(false);
    }

    public void LoadTo(string sceneName){
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName){
        FadeINOUT.color = new Color(1f,1f,1f,0f);
        FadeINOUT.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone){
            FadeINOUT.DOFade(1f, 2f);
            yield return new WaitForSeconds(2f);
            if(asyncOperation.progress >= 0.9f){
                asyncOperation.allowSceneActivation = true;            
            }

        }
    }
    
}
