using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMgr : MonoBehaviour
{
    [SerializeField] Image FadeINOUT;
    private void Awake() {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn(){
        FadeINOUT.gameObject.SetActive(true);
        FadeINOUT.color = new Color(0f,0f,0f,1f);
        FadeINOUT.DOFade(0f, 2f);
        yield return new WaitForSeconds(2f);
        FadeINOUT.gameObject.SetActive(false);
    }

    
}
