using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBtn : MonoBehaviour
{
    [SerializeField] public GameObject endingPanel;
    [SerializeField] AudioClip paperFlip;
    public void OnClick_EndingBtn(){
        AudioSource.PlayClipAtPoint(paperFlip, new Vector3(0f,0f,0f));

        if(endingPanel.activeInHierarchy){
            endingPanel.SetActive(false);
        }else{
            endingPanel.SetActive(true);
        }
    }

    public void TurnOnTheEndingPanel(){
        endingPanel.SetActive(true);
    }
}
