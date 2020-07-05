using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData", order = 0)]
[System.Serializable]
public class SaveData {
    
    [SerializeField] public bool midKilled = false;
    [SerializeField] public bool finKilled = false;
    [SerializeField] public int stageProgress = 0;
    [SerializeField] public bool[] openedEndings = {false,false,false};


    public SaveData(bool _midKilled, bool _finKilled, int _stageProgress, int _openedEndings, int _closeEnding){
        midKilled = _midKilled;
        finKilled = _finKilled;
        stageProgress = _stageProgress;
        if(_openedEndings != 99)
            openedEndings[_openedEndings] = true;
        if(_closeEnding != 99)
            openedEndings[_closeEnding] = false;
    }

    public void resetEnding(){
        for(int i = 0 ; i < openedEndings.Length; i++){
            openedEndings[i] = false;
        }
    }

}

