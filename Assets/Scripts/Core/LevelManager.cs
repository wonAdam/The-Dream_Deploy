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
        
        public FadeOUTIN fadeOUTIN;
        public GameOverPanel gameOverPanel;
        private void Start() {
            fadeOUTIN = FindObjectOfType<FadeOUTIN>();
            fadeOUTIN.gameObject.SetActive(false);
            gameOverPanel = FindObjectOfType<GameOverPanel>();
            gameOverPanel.gameObject.SetActive(false);
        }

        public void LoadSceneByName(string name)
        {
            SaveData saveData = SaveMgr.LoadData();
            // name이 Ending 이라면 경과를 검사하여 알맞는 엔딩으로 보내기.
            if(stageIndex == 5 && name == "Epilogue_0"){
                
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

            if(name == "Stage1")
            {
                SaveMgr.SaveData(1, false, false, false);
            }
            else if(name == "Stage2")
            {
                SaveMgr.SaveData(2, false, false, false);
            }
            else if(name == "Stage3")
            {
                SaveMgr.SaveData(3, false, false, false);
            }
            else if(name == "Stage4")
            {
                SaveMgr.SaveData(4, SaveMgr.LoadData().midKilled, SaveMgr.LoadData().finKilled, false);
            }
            else if(name == "Stage5")
            {
                SaveMgr.SaveData(5, SaveMgr.LoadData().midKilled, SaveMgr.LoadData().finKilled, false);
            }


            
            // name이 Ending 이라면 세이브 데이터를 초기화 및 엔딩모음집 열기.
        }


        IEnumerator LoadYourAsyncScene(string name)
        {
            if(name == "MainMenu_GO"){
                gameOverPanel.gameObject.SetActive(true);
                gameOverPanel.GetComponent<Image>().color = new Color(1f,1f,1f,0f);
            }
            else{
                fadeOUTIN.gameObject.SetActive(true);
                fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
            }
            if(name == "MainMenu_GO") name = "MainMenu";

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;

            Debug.Log(asyncLoad.progress);
            while (!asyncLoad.isDone)
            {
                if(name == "MainMenu_GO"){
                    gameOverPanel.GetComponent<Image>().DOFade(1f,3f);
                    yield return new WaitForSeconds(3f);          
                }
                else{
                    fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,asyncLoad.progress);
                    Debug.Log(asyncLoad.progress);                
                }

                if(asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;            
                }

                yield return null;
            }

        }
    }
}
