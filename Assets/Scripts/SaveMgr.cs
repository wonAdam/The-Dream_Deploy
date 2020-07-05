using UnityEngine;
using System.IO;
using System.Text;

public class SaveMgr : MonoBehaviour
{
    public static void SaveData(int stageProgress = 0, bool midKilled = false, bool finKilled = false, int endingToOpen = 99, int endingToClose = 99)
    {
        SaveData data = new SaveData(midKilled, finKilled, stageProgress, endingToOpen, endingToClose);
        string JsonData = JsonUtility.ToJson(data);

        string path = Path.Combine(Application.persistentDataPath, "save.json");
        using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
        {

            byte[] byteData = Encoding.UTF8.GetBytes(JsonData);

            stream.Write(byteData, 0, byteData.Length);

            stream.Close();


            Debug.Log(path + "// save completed");
        }




        // SaveData saveData = Resources.Load("SaveData") as SaveData;

        // saveData.finKilled = finKilled;
        // saveData.midKilled = midKilled;
        // saveData.stageProgress = stageProgress;

        // if(endingToOpen != 99){
        //     saveData.openedEndings[endingToOpen] = true;
        // }

        // try{
        //     if(File.Exists(Path.Combine(Application.persistentDataPath, "save.json"))){
        //         string jsonData = JsonUtility.ToJson(saveData);
        //         Debug.Log(jsonData);
        //         File.WriteAllText(Path.Combine(Application.persistentDataPath, "save.json"), jsonData);
        //     }
        //     else{
        //         File.Open(Path.Combine(Application.persistentDataPath, "save.json"), FileMode.CreateNew);
        //         string jsonData = JsonUtility.ToJson(saveData);
        //         Debug.Log(jsonData);
        //         File.WriteAllText(Path.Combine(Application.persistentDataPath, "save.json"), jsonData);
        //     }
        // }
        // catch{
        //     Debug.Log("Error");
        // }
        
    }

    public static SaveData LoadData()
    {

        string path = Path.Combine(Application.persistentDataPath, "save.json");
        using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
        {

            byte[] byteData = new byte[stream.Length];

            stream.Read(byteData, 0, byteData.Length);

            stream.Close();

            string JsonData = Encoding.UTF8.GetString(byteData);

            Debug.Log(path + "// load completed");
            Debug.Log(JsonData);

            return JsonUtility.FromJson<SaveData>(JsonData);

        }    
    }

    public static bool IsSaveExist(){
        if(File.Exists(Path.Combine(Application.persistentDataPath, "save.json")))
            return true;
        else 
            return false;
    }

    public static void ResetData()
    {
        SaveData(0, false, false, 99, 0);
        SaveData(0, false, false, 99, 1);
        SaveData(0, false, false, 99, 2);
    }
}
