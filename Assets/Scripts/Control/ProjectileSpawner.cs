using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour, IEnableByPhase
{
    LevelManager levelManager;
    GameObject[] projectiles;
    public bool spawningEnabled = true;
    private bool isSpawningCoolDownCounting = false;
    private float spawningPeriod = 100f;
    private float timerSec = 0f;

    // todo Observer Pattern
    public bool isEnabled = true; // After Tutorial, should be true. After Battle, should be false


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        spawningPeriod = levelManager.SpawningPeriod;
        projectiles = levelManager.Projectiles;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled)
        {
            if(isSpawningCoolDownCounting) 
            {

                return;
            }
            if(spawningEnabled)
            {

            }
        }
        
    }

    private void RequestDataFromLevelManager()
    {

    }

    private void RandomSpawn()
    {

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
