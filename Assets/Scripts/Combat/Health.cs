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
        [SerializeField] bool isBoss = false;
        [SerializeField] LayerMask takeDamageLayerMask;
        [SerializeField] SpriteRenderer ONLY_BossSR;
        public int damageCount = 0;
        public EventObject playerDeadEvent;
        public List<Image> healthUIs;
        public int currHealth;
        SpriteRenderer mySR;
        Rigidbody2D myRb;
        Collider2D myCol;
        HealthUI healthUI;

        void Start()
        {
            currHealth = maxHealth;
            if(gameObject.tag == "Player")
                mySR = GetComponent<SpriteRenderer>();
            else if(gameObject.tag == "Enemy")
            {
                mySR = ONLY_BossSR;
            }
            myRb = GetComponent<Rigidbody2D>();
            myCol = GetComponent<Collider2D>();
            healthUI = FindObjectOfType<HealthUI>();
            if(healthUI != null && isPlayer)
            {
                healthUI.SetMaxHealth(maxHealth);
            }
        }

        public bool canBeDamaged()
        {
            return damageTakingDelayEnabled; 
        }

        public bool TakeDamage(int damage)
        {
            if(!damageTakingDelayEnabled) return false;

            currHealth = Mathf.Max(currHealth - damage, 0);
            StartCoroutine(DamageTakingEffect());

            if(isPlayer)
                healthUI.UpdateHealthUI(currHealth);

            if(isBoss)
            {
                damageCount++;
            }
            

            if(currHealth == 0)
            {
                // Death Process
                if(isPlayer)
                {
                    playerDeadEvent?.OnOccure();
                }
                if(isBoss)
                {

                }
            }
            return true;
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


            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.layerMask = takeDamageLayerMask;
            List<Collider2D> result = new List<Collider2D>();

            Debug.Log("Check");
            if(myCol.OverlapCollider(contactFilter, result) > 0)
            {
                Debug.Log("Something inside me");
                foreach(Collider2D c in result){
                    Debug.Log(c.gameObject.name);
                    if(c.GetComponent<Toucher>() != null)
                    {
                        Debug.Log("Attacked");
                        c.GetComponent<Toucher>().Attack(myCol);
                        break;
                    }
                }
            }
        }


    }
}
