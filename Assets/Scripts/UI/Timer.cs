using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;
using UnityEngine.UI;
namespace ADAM.UI
{
    public class Timer : MonoBehaviour, IEnableByPhase
    {
        [SerializeField] float startTime = 60f;
        public EventObject timerEndEvent;
        LevelManager levelManager;
        float currTime;
        public Text timeTxt;

        public bool timerEnabled = true;
        // Start is called before the first frame update
        void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();

            if(!levelManager.TimerEnable)
            {
                gameObject.SetActive(false);
                return;
            }

            startTime = levelManager.StageTime;
            timeTxt = GetComponentInChildren<Text>();
            timeTxt.text = ((int)startTime).ToString();
            currTime = startTime;


            // subscribe to StageEnd_TimeUpEvent
        }

        // Update is called once per frame
        void Update()
        {
            if(timerEnabled)
                TikTok();
            
        }

        public void TikTok()
        {
            if(currTime <= 0f) 
            { 
                // Occure Event to StageEnd_TimeUpEvent    
                timerEndEvent.OnOccure();
                timerEnabled = false;
                return;
            }

            currTime -= Time.deltaTime;

            timeTxt.text = ((int)currTime).ToString();
        }

        public void StartActing()
        {
            // todo Observer Pattern
        }

        public void StopActing()
        {
            // todo Observer Pattern
        }
    }
}
