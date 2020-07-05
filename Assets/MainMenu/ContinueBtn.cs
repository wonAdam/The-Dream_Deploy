using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueBtn : MonoBehaviour
{
    [SerializeField] Image FadeinOut;
    // Start is called before the first frame update
    void Start()
    {
        if(!SaveMgr.IsSaveExist()){
            SaveMgr.ResetData();
        }

        if(SaveMgr.LoadData().stageProgress == 0){
            GetComponent<Button>().interactable = false;
        } 
        else{
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnClick_ContinueBtn(){
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad(){
        string stage = "Stage";

        stage += SaveMgr.LoadData().stageProgress.ToString();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(stage);
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
