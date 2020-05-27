using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Core
{
    public class ToGameBtn : MonoBehaviour
    {
        [SerializeField] GameObject pausePanel;
        public void OnClick_ToGameBtn()
        {
            pausePanel.SetActive(false);
        }
    }
}
