using System.Collections;
using System.Collections.Generic;
using ADAM.UI;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ADAM.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 100;
        [SerializeField] bool damageTakingDelayEnabled = true;
        [SerializeField] int blinkingCount = 20;
        [SerializeField] float blinkingEffectDuration = 2f;
        [SerializeField] bool isPlayer = false;
        public EventObject playerDeadEvent;
        public List<Image> healthUIs;
        public int currHealth;
        SpriteRenderer mySR;
        Rigidbody2D myRb;
        HealthUI healthUI;

        void Start()
        {
            currHealth = maxHealth;
            mySR = GetComponent<SpriteRenderer>();
            myRb = GetComponent<Rigidbody2D>();
            healthUI = FindObjectOfType<HealthUI>();
            if(healthUI != null)
            {
                healthUI.SetMaxHealth(maxHealth);
            }
        }

        public bool TakeDamage(int damage)
        {
            if(!damageTakingDelayEnabled) return false;

            currHealth = Mathf.Max(currHealth - damage, 0);
            StartCoroutine(DamageTakingEffect());

            if(isPlayer)
                healthUI.UpdateHealthUI(currHealth);

            if(currHealth == 0)
            {
                // Death Process
                if(isPlayer)
                {
                    playerDeadEvent?.OnOccure();
                }
            }
            return true;
        }

        public void PushedBack(Vector2 attackerPos)
        {
            Vector2 dir = (Vector2)transform.position - attackerPos;
            myRb.AddForce(dir * 200f);
        }

        private IEnumerator DamageTakingEffect()
        {
            damageTakingDelayEnabled = false;
            for(int i = 0 ; i < blinkingCount; i++)
            {
                mySR.DOFade(0f, blinkingEffectDuration / blinkingCount / 2f);
                yield return new WaitForSeconds(blinkingEffectDuration / blinkingCount / 2f);
                mySR.DOFade(1f, blinkingEffectDuration / blinkingCount / 2f);
                yield return new WaitForSeconds(blinkingEffectDuration / blinkingCount / 2f);
            }
            damageTakingDelayEnabled = true;
        }


    }
}
