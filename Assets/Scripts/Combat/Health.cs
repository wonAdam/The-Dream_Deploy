using System.Collections;
using System.Collections.Generic;
using ADAM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ADAM.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 100;
        [SerializeField] bool damageTakingDelayEnabled = true;
        List<Image> healthUIs;
        int currHealth;

        // Start is called before the first frame update
        void Start()
        {
            currHealth = maxHealth;
            HeartUI[] hearts = FindObjectsOfType<HeartUI>();
            for(int i = 0 ; i < hearts.Length; i++)
            {
                for(int j = 0 ; j <hearts.Length; j++)
                {
                    if(hearts[j].index == i) healthUIs.Add(hearts[j].GetComponent<Image>());
                }
            }
        }

        public bool TakeDamage(int damage)
        {
            if(damageTakingDelayEnabled) return false;

            currHealth = Mathf.Max(currHealth - damage, 0);
            UpdateHealthUI();
            if(currHealth == 0)
            {
                // Death Process
            }
            return true;
        }

        private void UpdateHealthUI()
        {
            int healthPerHeart = maxHealth / healthUIs.Count;

            int healthCache = currHealth;
            for(int i = 0 ; i < healthUIs.Count; i++)
            {
                if(healthCache >= healthPerHeart)
                {
                    healthCache -= healthPerHeart;
                    healthUIs[i].fillAmount = 1f;
                }
                else
                {
                    healthUIs[i].fillAmount = healthCache / (float)healthPerHeart;
                    healthCache = 0;
                }
                
            }
        }
    }
}
