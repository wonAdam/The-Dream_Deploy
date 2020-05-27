using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Core
{
    public class PauseBtn : MonoBehaviour
    {
        [SerializeField] GameObject pausePanel;
        public void OnClick_PauseBtn()
        {
            pausePanel.SetActive(true);
        }
    }
}
