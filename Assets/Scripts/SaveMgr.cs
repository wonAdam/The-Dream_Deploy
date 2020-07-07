using UnityEngine;
using System.IO;
using System.Text;

public class SaveMgr : MonoBehaviour
{
    public static void SaveData(int stageProgress = 0, bool midKilled = false, bool finKilled = false, bool isFirstTimePlay = true, int endingToOpen = 99, int endingToClose = 99)
    {
        SaveData data = new SaveData(midKilled, finKilled, stageProgress, isFirstTimePlay, endingToOpen, endingToClose);
        string JsonData = JsonUtility.ToJson(data);

        string path = Path.Combine(Application.persistentDataPath, "save.json");
        using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
        {

            byte[] byteData = Encoding.UTF8.GetBytes(JsonData);

            stream.Write(byteData, 0, byteData.Length);

            stream.Close();


            Debug.Log(path + "// save completed");
        }
    }

    public static void SaveData(SaveData saveData){
        string JsonData = JsonUtility.ToJson(saveData);
        Debug.Log("SaveData" + JsonData);

        string path = Path.Combine(Application.persistentDataPath, "save.json");
        using (FileStream stream = File.Open(path, FileMode.Create))
        {

            byte[] byteData = Encoding.UTF8.GetBytes(JsonData);

            stream.Write(byteData, 0, byteData.Length);

            stream.Close();


            Debug.Log(path + "// save completed");
        }    
    }

    public static SaveData LoadData()
    {

        string path = Path.Combine(Application.persistentDataPath, "save.json");
        using (FileStream stream = File.Open(path, FileMode.Open))
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
        SaveData(0, false, false, true ,99, 0);
        SaveData(0, false, false, true ,99, 1);
        SaveData(0, false, false, true ,99, 2);
    }
}
