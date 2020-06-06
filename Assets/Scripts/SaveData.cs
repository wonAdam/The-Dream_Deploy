using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData", order = 0)]
public class SaveData : ScriptableObject {
    
    [SerializeField] public bool midKilled = false;
    [SerializeField] public bool finKilled = false;
    [SerializeField] public int stageProgress = 0;

}

