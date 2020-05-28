using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;

public class ShootBtn : MonoBehaviour
{
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if(!levelManager.PencilEnable) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
