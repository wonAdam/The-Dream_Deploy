using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;

namespace ADAM.UI{
    public class BossAskingPanel : MonoBehaviour
    {
        [SerializeField] public EventObject endOfBossAsking_No;
        [SerializeField] public EventObject endOfBossAsking_Yes;
        [SerializeField] AudioClip paperFlip;
        public bool YesOrNo = false;
        Animator myAnim;
        
        private void OnEnable() {
            AudioSource.PlayClipAtPoint(paperFlip, new Vector3(0f,0f,0f));
            myAnim = GetComponent<Animator>();
            myAnim.SetBool("isAsking", true);
        }

        private void OnDisable() {
            AudioSource.PlayClipAtPoint(paperFlip, new Vector3(0f,0f,0f));
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
            myAnim.SetBool("isAsking", false);
            YesOrNo = true;
        }
        public void OnClick_No(){
            myAnim.SetBool("isAsking", false);
            YesOrNo = false;
        }
    }
}
