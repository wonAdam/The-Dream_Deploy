using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader_Debug : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadToStage1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadToStage2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadToStage3()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadToStage4()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadToStage5()
    {
        SceneManager.LoadScene(5);
    }
}
