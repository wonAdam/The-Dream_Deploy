using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;
using DG.Tweening;

namespace ADAM.UI{
    public class BossAskingPanel : MonoBehaviour
    {
        [SerializeField] public EventObject endOfBossAsking_No;
        [SerializeField] public EventObject endOfBossAsking_Yes;
        [SerializeField] public AudioClip paperFlip;
        public bool YesOrNo = false;
        public AudioSource[] allOtherAS;
        Animator myAnim;
        
        private void OnEnable() {
            allOtherAS = FindObjectsOfType<AudioSource>();
            for(int i = 0 ; i < allOtherAS.Length; i++){
                allOtherAS[i].DOFade(0f, 0.2f);
            }
            AudioSource.PlayClipAtPoint(paperFlip,new Vector3(0,0,0), 1f);
            myAnim = GetComponent<Animator>();
            myAnim.SetBool("isAsking", true);
        }

        public void EndOfBossAsking(){
            if(YesOrNo){
                endOfBossAsking_Yes.OnOccure();
            }
            else{
                endOfBossAsking_No.OnOccure();
                gameObject.SetActive(false);
            }
            
        }

        public void OnClick_Yes(){
            SaveData saveData = SaveMgr.LoadData();
            if(saveData.stageProgress == 4){
                saveData.midKilled = false;
            }
            else{
                saveData.finKilled = false;
            }
            SaveMgr.SaveData(saveData);

            AudioSource.PlayClipAtPoint(paperFlip,new Vector3(0,0,0), 1f);
            myAnim.SetBool("isAsking", false);
            YesOrNo = true;
        }
        public void OnClick_No(){
            for(int i = 0 ; i < allOtherAS.Length; i++){
                allOtherAS[i].DOFade(1f, 2f);
            }

            SaveData saveData = SaveMgr.LoadData();
            if(saveData.stageProgress == 4){
                saveData.midKilled = true;
            }
            else{
                saveData.finKilled = true;
            }
            SaveMgr.SaveData(saveData);

            AudioSource.PlayClipAtPoint(paperFlip, new Vector3(0,0,0), 1f);
            myAnim.SetBool("isAsking", false);
            YesOrNo = false;
        }
    }
}
