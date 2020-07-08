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
    [SerializeField] public bool isFirstTimePlay = true;


    public SaveData(bool _midKilled, bool _finKilled, int _stageProgress, bool _isFirstTimePlay = true, int _openedEndings = 99, int _closeEnding = 99){
        midKilled = _midKilled;
        finKilled = _finKilled;
        stageProgress = _stageProgress;
        isFirstTimePlay = _isFirstTimePlay;

        if(_openedEndings != 99)
            openedEndings[_openedEndings] = true;
        if(_closeEnding != 99)
            openedEndings[_closeEnding] = false;
    }

    public SaveData(bool _midKilled, bool _finKilled, int _stageProgress, bool[] _openedEndings, bool _isFirstTimePlay = true){
        for(int i = 0; i < 3; i++){
            openedEndings[i] = _openedEndings[i];
        }
        midKilled = _midKilled;
        finKilled = _finKilled;
        stageProgress = _stageProgress;
        isFirstTimePlay = _isFirstTimePlay;    
    }


}

