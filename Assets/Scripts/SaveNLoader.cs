using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveNLoader : MonoBehaviour
{
    [SerializeField] int epilogueIndex;
    // Start is called before the first frame update
    void Start()
    {
        SaveData saveData = SaveMgr.LoadData();
        saveData.openedEndings[epilogueIndex] = true;
        SaveMgr.SaveData(saveData);
    }

    public void LoadToMain(){
        SceneManager.LoadScene("MainMenu");
    }

    
}
