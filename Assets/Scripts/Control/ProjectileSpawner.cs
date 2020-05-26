using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;


namespace ADAM.Control
{
    public class ProjectileSpawner : MonoBehaviour, IEnableByPhase
    {
        LevelManager levelManager;
        GameObject[] projectiles;
        public bool spawningEnabled = true;
        private bool isSpawningCoolDownCounting = false;
        private float spawningPeriod = 100f;
        private float timerSec = 0f;

        // todo Observer Pattern | revert to false after implement tutorial
        public bool isEnabled = true; // After Tutorial, should be true. After Battle, should be false


        // Start is called before the first frame update
        void Start()
        {
            RequestDataFromLevelManager();
        }

        // Update is called once per frame
        void Update()
        {
            if(isEnabled)
            {
                if(isSpawningCoolDownCounting) 
                {
                    SpawningCoolDownTikTok();
                    return;
                }
                if(spawningEnabled)
                {
                    RandomSpawn();
                }
            }
            
        }

        private void RequestDataFromLevelManager()
        {
            levelManager = FindObjectOfType<LevelManager>();
            spawningPeriod = levelManager.SpawningPeriod;
            projectiles = levelManager.Projectiles;        
        }

        private void SpawningCoolDownTikTok()
        {
            timerSec += Time.deltaTime;
            if(timerSec >= spawningPeriod)
            {
                timerSec = 0f;
                isSpawningCoolDownCounting = false;
            }
        }

        private void RandomSpawn()
        {
            int randIndex = Random.Range(0, projectiles.Length);
            int randDir = Random.Range(-1, 1);
            float randXPos = randDir < 0 ? -10f : 10f;
            float randYPos = Random.Range(-4f, 4f);

            Instantiate(projectiles[randIndex], new Vector2(randXPos, randYPos), Quaternion.identity);

            isSpawningCoolDownCounting = true;
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
