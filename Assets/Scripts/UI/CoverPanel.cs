using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ADAM.UI
{
    public class CoverPanel : MonoBehaviour
    {
        [SerializeField] Text coverText;
        [SerializeField] EventObject e_StartPhaseEnd;
        [SerializeField] EventObject e_ClearPhaseEnd;
        Animator myAnim;
        private void OnEnable() {
            myAnim = GetComponent<Animator>();
        }

        public void SetText(string content)
        {
            coverText.text = content;
        }

        public void OnClick_CoverPanel()
        {
            myAnim.SetTrigger("Clicked");
        }

        public void EndOfFadeOutBattleAnimation()
        {
            e_StartPhaseEnd.OnOccure();
        }
        public void EndOfFadeOutClearAnimation()
        {
            e_ClearPhaseEnd.OnOccure();
        }


    }
}
