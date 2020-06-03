using System.Collections;
using System.Collections.Generic;
using ADAM.UI;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using ADAM.Movement;

namespace ADAM.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] AudioClip damageSound;
        [SerializeField] public EventObject playerDeadEvent;
        [SerializeField] public EventObject bossDeadEvent;
        [SerializeField] int maxHealth = 100;
        [SerializeField] bool damageTakingDelayEnabled = true;
        [SerializeField] float blinkingEffectDuration = 2f;
        [SerializeField] bool isPlayer = false;
        [SerializeField] bool isBoss = false;
        [SerializeField] LayerMask takeDamageLayerMask;
        [SerializeField] bool isFinBoos = false;
        private bool blinkingEffectEnable = false;
        private float currBlinkingTikTok = 0f;
        private int damageCount = 0;
        private List<Image> healthUIs;
        public int currHealth;
        Animator myAnim;
        Rigidbody2D myRb;
        Collider2D myCol;
        HealthUI healthUI;
        HealthBar healthBar;
        Mover mover;

        void Start()
        {
            currHealth = maxHealth;
            myAnim = GetComponent<Animator>();
            myRb = GetComponent<Rigidbody2D>();
            myCol = GetComponent<Collider2D>();
            mover = GetComponent<Mover>();
            if(isPlayer)
                healthUI = FindObjectOfType<HealthUI>();
            
            if(isBoss)
                healthBar = GetComponentInChildren<HealthBar>();

            if(healthUI != null && isPlayer)
            {
                healthUI.SetMaxHealth(maxHealth);
            }
        }

        private void Update() {
            if(blinkingEffectEnable)
                DamageTakingEffectTikTok();
        }

        public bool canBeDamaged()
        {
            return damageTakingDelayEnabled; 
        }

        public bool TakeDamage(int damage)
        {
            if(!damageTakingDelayEnabled) return false;

            currHealth = Mathf.Max(currHealth - damage, 0);


            if(isPlayer)
                healthUI.UpdateHealthUI(currHealth);
            if(isBoss)
                healthBar.SetHealthBarUI(currHealth/(float)maxHealth);

            GetComponent<AudioSource>().PlayOneShot(damageSound);

                
            // if this health is dead
            if(currHealth == 0)
            {
                // Death Process
                if(isPlayer)
                {
                    playerDeadEvent?.OnOccure();
                    return true;
                }
                if(isBoss)
                {
                    myAnim.SetBool("Dead", true);
                    bossDeadEvent.OnOccure();
                    return true;
                }
            }


            currBlinkingTikTok = 0f;
            blinkingEffectEnable = true;

                

            if(isBoss)
            {
                damageCount++;
            }
            

            if(isFinBoos && currHealth / (float)maxHealth <= 0.15f)
            {
                myAnim.SetBool("Berserker", true);
                mover.SetMoveSpeed(100f);
            }


            return true;
        }

        public void Heal(int amount)
        {
            currHealth = Mathf.Min(currHealth + amount, maxHealth);
            if(isPlayer)
                healthUI.UpdateHealthUI(currHealth);

            if(isBoss)
                healthBar.SetHealthBarUI(currHealth/(float)maxHealth);
            
        }


        private void DamageTakingEffectTikTok()
        {
            currBlinkingTikTok += Time.deltaTime;
            myAnim.SetBool("Damage", true);

            if(isPlayer)
                damageTakingDelayEnabled = false;

            if(currBlinkingTikTok >= blinkingEffectDuration)
            {
                damageTakingDelayEnabled = true;
                myAnim.SetBool("Damage", false);
                blinkingEffectEnable = false;


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
        // private IEnumerator DamageTakingEffect()
        // {
        //     if(isPlayer)
        //         damageTakingDelayEnabled = false;

        //     myAnim.SetBool("Damage", true);

        //     yield return new WaitForSeconds(blinkingEffectDuration);
            
        //     myAnim.SetBool("Damage", false);

        //     if(isPlayer)
        //         damageTakingDelayEnabled = true;



        //     ContactFilter2D contactFilter = new ContactFilter2D();
        //     contactFilter.layerMask = takeDamageLayerMask;
        //     List<Collider2D> result = new List<Collider2D>();

        //     Debug.Log("Check");
        //     if(myCol.OverlapCollider(contactFilter, result) > 0)
        //     {
        //         Debug.Log("Something inside me");
        //         foreach(Collider2D c in result){
        //             Debug.Log(c.gameObject.name);
        //             if(c.GetComponent<Toucher>() != null)
        //             {
        //                 Debug.Log("Attacked");
        //                 c.GetComponent<Toucher>().Attack(myCol);
        //                 break;
        //             }
        //         }
        //     }
        // }


    }
}
