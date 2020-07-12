using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;

namespace ADAM.UI
{
    public class ToMainBtn : MonoBehaviour
    {

        public EventObject _event;
        public LevelManager levelManager;
        public Timer timer;
        private void OnEnable() {
            levelManager = FindObjectOfType<LevelManager>();
            timer = FindObjectOfType<Timer>();
        }

        public void OnClick_ToMainBtn()
        {  
            _event.OnOccure();
            timer.timerEnabled = false;
            Time.timeScale = 1f;
        }
    }
}
