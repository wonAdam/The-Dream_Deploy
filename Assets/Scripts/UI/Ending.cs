using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] int endingIndex;
    MainMenuMgr mainMenuMgr;
    public Image myImage;
    public Text myText;
    public bool isOn;
    private void OnEnable() {
        mainMenuMgr = FindObjectOfType<MainMenuMgr>();
        myImage = GetComponent<Image>();
        myText = GetComponentInChildren<Text>();
    }
    public void On(){
        myImage.color = new Color(1f,1f,1f,1f);
        myText.color = new Color(1f,1f,1f,0f);
        isOn = true;
    }
    public void Off(){
        myImage.color = new Color(0f,0f,0f,1f);
        myText.color = new Color(1f,1f,1f,1f);
        isOn = false;
    }

    public void OnClick_Ending(){
        if(isOn){
            string sceneName = "Epilogue_0" + endingIndex.ToString();
            mainMenuMgr.LoadTo(sceneName);
        }
    }
}
