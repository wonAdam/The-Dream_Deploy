using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveFileSafer : MonoBehaviour
{
    private void Awake() {
        string path = Path.Combine(Application.persistentDataPath, "save.json");

        if(!File.Exists(path)){
            SaveMgr.SaveData(new SaveData(false, false, 0));
        }
    }
}
