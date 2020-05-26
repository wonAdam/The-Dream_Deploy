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

        FadeOUTIN fadeOUTIN;
        private void Start() {
            fadeOUTIN = FindObjectOfType<FadeOUTIN>();
            fadeOUTIN.gameObject.SetActive(false);
        }

        public void LoadSceneByIndex(int index)
        {
            StartCoroutine(LoadYourAsyncScene(index));
        }

        IEnumerator LoadYourAsyncScene(int index)
        {

            fadeOUTIN.gameObject.SetActive(true);
            fadeOUTIN.GetComponent<Image>().color = new Color(0f,0f,0f,0f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
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
