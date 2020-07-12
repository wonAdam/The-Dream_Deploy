using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ADAM.Core
{

    // 현재 스테이지에 대한 정보들과 스테이지에서 다른 스테이지로의 로드를 책임집니다.
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
        
        public FadeOUTIN fadeOUTIN;
        public GameOverPanel gameOverPanel;
        public AudioSource myAS;
        private void Start() {
            fadeOUTIN = FindObjectOfType<FadeOUTIN>();
            fadeOUTIN.gameObject.SetActive(false);
            myAS = GetComponent<AudioSource>();

            SaveData saveData = SaveMgr.LoadData();
            saveData.isFirstTimePlay = false;
            SaveMgr.SaveData(saveData);
        }

        public void LoadSceneByName(string name)
        {
            SaveData saveData = SaveMgr.LoadData();
            // name이 Ending 이라면 경과를 검사하여 알맞는 엔딩으로 보내기.
            if(name == "Epilogue_0"){
                
                saveData.stageProgress = 0;
                saveData.isFirstTimePlay = false;
                SaveMgr.SaveData(saveData);

                if(saveData.finKilled && saveData.midKilled){
                    name += 1.ToString();
                }
                else if(saveData.finKilled || saveData.midKilled){
                    name += 2.ToString();
                }
                else{
                    name += 3.ToString();
                }
            }

            StartCoroutine(LoadYourAsyncScene(name));

            SaveStageProgress(name);

        }

        public void LoadWithoutFade(string name){
            if(name == "Epilogue_0"){
                LoadSceneByName(name);
                return;
            }
            SaveStageProgress(name);
            SceneManager.LoadScene(name);
        }

        private void SaveStageProgress(string name){
            SaveData saveData = SaveMgr.LoadData();
            if(name == "Stage1")
            {
                saveData.stageProgress = 1;
                saveData.finKilled = false;
                saveData.midKilled = false;
                SaveMgr.SaveData(saveData);
            }
            else if(name == "Stage2")
            {
                saveData.stageProgress = 2;
                saveData.finKilled = false;
                saveData.midKilled = false;
                SaveMgr.SaveData(saveData);
            }
            else if(name == "Stage3")
            {
                saveData.stageProgress = 3;
                saveData.finKilled = false;
                saveData.midKilled = false;
                SaveMgr.SaveData(saveData);
            }
            else if(name == "Stage4")
            {
                saveData.stageProgress = 4;
                saveData.midKilled = false;
                saveData.finKilled = false;
                SaveMgr.SaveData(saveData);
            }
            else if(name == "Stage5")
            {
                saveData.stageProgress = 5;
                saveData.finKilled = false;
                SaveMgr.SaveData(saveData);
            }        
        }


        IEnumerator LoadYourAsyncScene(string name)
        {
            
            fadeOUTIN.gameObject.SetActive(true);
            fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
            

            AsyncOperation asyncLoad  = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;


            myAS.DOFade(0f, 2f);

            fadeOUTIN.GetComponent<Image>().DOFade(1f,3f);   
            yield return new WaitForSeconds(3f);      
            asyncLoad.allowSceneActivation = true;       
        }
    }
}
