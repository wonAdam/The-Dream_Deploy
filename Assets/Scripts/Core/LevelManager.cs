using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace ADAM.Core
{
    public class LevelManager : MonoBehaviour
    {

        [SerializeField] int stageIndex = 1;
        public int StageIndex {
            get
            {
                return stageIndex;
            } 
        }
        [SerializeField] GameObject[] projectiles;
        public GameObject[] Projectiles
        {
            get{
                return projectiles;
            }
        }
        [SerializeField] float stageTime = 60f;
        public float StageTime{
            get{
                return stageTime;
            }
        }
        [SerializeField] float spawningPeriod = 1.5f;
        public float SpawningPeriod
        {
            get{
                return spawningPeriod;
            }
        }
        [SerializeField] bool timerEnable = true;
        public bool TimerEnable{
            get{
                return timerEnable;
            }
        }
        [SerializeField] bool pencilEnable = false;
        public bool PencilEnable{
            get{
                return pencilEnable;
            }
        }
        
        FadeOUTIN fadeOUTIN;
        private void Start() {
            fadeOUTIN = FindObjectOfType<FadeOUTIN>();
            fadeOUTIN.gameObject.SetActive(false);
        }

        public void LoadSceneByName(string name)
        {
            StartCoroutine(LoadYourAsyncScene(name));

            if(name == "Stage1")
            {
                SaveMgr.SaveData(1);
            }
            else if(name == "Stage2")
            {
                SaveMgr.SaveData(2);
            }
            else if(name == "Stage3")
            {
                SaveMgr.SaveData(3);
            }
            else if(name == "Stage4")
            {
                SaveMgr.SaveData(4, SaveMgr.LoadData().midKilled, SaveMgr.LoadData().finKilled);
            }
            else if(name == "Stage5")
            {
                SaveMgr.SaveData(5, SaveMgr.LoadData().midKilled, SaveMgr.LoadData().finKilled);
            }
        }

        public void MidBossKilled()
        {
            SaveMgr.SaveData(5, true, SaveMgr.LoadData().finKilled);
        }

        public void FinBossKilled()
        {
            SaveMgr.SaveData(0, SaveMgr.LoadData().midKilled, true);
        }


        IEnumerator LoadYourAsyncScene(string name)
        {

            fadeOUTIN.gameObject.SetActive(true);
            fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,asyncLoad.progress);
                Debug.Log(asyncLoad.progress);

                if(asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;            
                }

                yield return null;
            }

        }
    }
}
