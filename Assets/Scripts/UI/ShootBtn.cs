using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;

namespace ADAM.UI
{
    public class ShootBtn : MonoBehaviour
    {
        LevelManager levelManager;
        // Start is called before the first frame update
        void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();
            if(!levelManager.PencilEnable) gameObject.SetActive(false);
        }

    }
}
