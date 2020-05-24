using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ADAM.UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] float startTime = 60f;
        float currTime;
        public Text timeTxt;
        public bool timerEnabled = true;
        // Start is called before the first frame update
        void Start()
        {
            timeTxt = GetComponentInChildren<Text>();
            currTime = startTime;
        }

        // Update is called once per frame
        void Update()
        {
            if(timerEnabled)
                TikTok();
            
        }

        public void TikTok()
        {
            if(currTime <= 0f) return;

            currTime -= Time.deltaTime;

            timeTxt.text = ((int)currTime).ToString();
        }
    }
}
