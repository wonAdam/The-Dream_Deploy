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
        [SerializeField] public EventObject playerDeadEvent;
        [SerializeField] int maxHealth = 100;
        [SerializeField] bool damageTakingDelayEnabled = true;
        [SerializeField] float blinkingEffectDuration = 2f;
        [SerializeField] bool isPlayer = false;
        [SerializeField] bool isBoss = false;
        [SerializeField] LayerMask takeDamageLayerMask;
        private int damageCount = 0;
        private List<Image> healthUIs;
        public int currHealth;
        Animator myAnim;
        Rigidbody2D myRb;
        Collider2D myCol;
        HealthUI healthUI;

        void Start()
        {
            currHealth = maxHealth;
            myAnim = GetComponent<Animator>();
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
            

            // if this health is dead
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
            myAnim.SetTrigger("Damage");

            yield return new WaitForSeconds(blinkingEffectDuration);
            
            damageTakingDelayEnabled = true;
            myAnim.SetTrigger("Damage");



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
