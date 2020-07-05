using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugBtn : MonoBehaviour
{
    public void OnClick_DebugBtn(){
        SceneManager.LoadScene("DebugScene");
    }
}
