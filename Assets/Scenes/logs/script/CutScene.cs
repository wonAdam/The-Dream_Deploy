using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{

    [SerializeField] Animator anim;


    public void OnClickScene()
    {
        anim.SetTrigger("NextScene");
        Debug.Log("Trigger Set");
    }

}