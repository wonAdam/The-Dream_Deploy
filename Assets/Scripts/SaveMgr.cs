using UnityEngine;

public class SaveMgr : MonoBehaviour
{
    public static void SaveData(int stageProgress = 0, bool midKilled = false, bool finKilled = false)
    {
        SaveData saveData = Resources.Load("SaveData") as SaveData;

        saveData.finKilled = finKilled;
        saveData.midKilled = midKilled;
        saveData.stageProgress = stageProgress;
    }

    public static SaveData LoadData()
    {
        return Resources.Load("SaveData") as SaveData;
    }

    public void ResetData()
    {
        SaveData saveData = Resources.Load("SaveData") as SaveData;
        
        saveData.finKilled = false;
        saveData.midKilled = false;
        saveData.stageProgress = 0;
    }
}
