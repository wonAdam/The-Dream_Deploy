using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] GameObject skipBtn;

    private void OnEnable() {
        SaveData saveData = SaveMgr.LoadData();
        if(saveData.isFirstTimePlay == true){
            Destroy(skipBtn);
        }
    }

    public void OnClickScene()
    {
        anim.SetTrigger("FinalScene");
        Debug.Log("Trigger Set");
    }

}
