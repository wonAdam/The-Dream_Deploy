using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader_Debug : MonoBehaviour
{

    public void LoadToStage1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void LoadToStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void LoadToStage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void LoadToStage5()
    {
        SceneManager.LoadScene("Stage5");
    }
}
