using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
            // coverPanel.gameObject.SetActive(true);
            // coverPanel.GetComponent<Animator>().SetTrigger("Start");
            // coverPanel.SetText(clearMessage);
public class GameOverPanel : MonoBehaviour
{
    [SerializeField]public EventObject gameOverPhaseEnded;
    public void GameOverPhaseEnded(){
        gameOverPhaseEnded.OnOccure();
    }
}
