using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;
using UnityEngine.UI;

namespace  ADAM.UI
{
    public class PencilUI : MonoBehaviour
    {
        [SerializeField] Text pencilText;
        LevelManager levelManager;

        private void Start() {
            levelManager = FindObjectOfType<LevelManager>();
            if(!levelManager.PencilEnable) gameObject.SetActive(false);
        }
        public void UpdatePencilCount(int count)
        {
            pencilText.text = count.ToString();
        }
    }
}
