using System.Collections;
using System.Collections.Generic;
using ADAM.Core;
using UnityEngine;

namespace ADAM.UI{
    public class BossAskingPanel : MonoBehaviour
    {
        [SerializeField] public EventObject endOfBossAsking_No;
        [SerializeField] public EventObject endOfBossAsking_Yes;
        public bool YesOrNo = false;
        Animator myAnim;
        
        private void OnEnable() {
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
            myAnim.SetBool("isAsking", false);
            YesOrNo = true;
        }
        public void OnClick_No(){
            myAnim.SetBool("isAsking", false);
            YesOrNo = false;
        }
    }
}
