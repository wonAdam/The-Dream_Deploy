using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsPanel : MonoBehaviour
{
    [SerializeField] Ending[] endings;
    // Start is called before the first frame update
    void Start()
    {
        SaveData saveData = SaveMgr.LoadData();

        for(int i = 0; i < saveData.openedEndings.Length; i++){
            if(saveData.openedEndings[i]){
                endings[i].On();
            }
            else{
                endings[i].Off();
            }
        }
    }

}
