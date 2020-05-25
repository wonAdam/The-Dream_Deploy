using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int stageIndex = 1;
    public int StageIndex {
        get
        {
            return stageIndex;
        } 
    }
    [SerializeField] GameObject[] projectiles;
    public GameObject[] Projectiles
    {
        get{
            return projectiles;
        }
    }
    [SerializeField] float stageTime = 60f;
    public float StageTime{
        get{
            return stageTime;
        }
    }
    [SerializeField] float spawningPeriod = 1.5f;
    public float SpawningPeriod
    {
        get{
            return spawningPeriod;
        }
    }

}
