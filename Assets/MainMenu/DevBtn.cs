using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevBtn : MonoBehaviour
{
    [SerializeField] AudioClip paperFlip;
    [SerializeField] GameObject devPanel;
    public void OnClick_DevBtn(){
        if(devPanel.activeInHierarchy)
        {
            devPanel.SetActive(false);
        }
        else{
            devPanel.SetActive(true);
        }

        AudioSource.PlayClipAtPoint(paperFlip, new Vector3(0f,0f,0f), 1f);

    }
}
