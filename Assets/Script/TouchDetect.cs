using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour
{
    public void NextSceneTrigger()
    {
        GetComponent<Animator>().SetTrigger("NextScene");
    }
}