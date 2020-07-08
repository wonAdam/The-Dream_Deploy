using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfPrologue : MonoBehaviour
{
    public void LoadAtEndOfPrologue(){
        SaveData saveData = SaveMgr.LoadData();

        if(saveData.isFirstTimePlay){
            SceneManager.LoadScene("Description1");
        }
        else{
            SceneManager.LoadScene("Stage1");
        }
    }
}
