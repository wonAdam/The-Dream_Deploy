using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ADAM.UI
{
    public class HealthUI : MonoBehaviour {
        public HeartUI[] heartUIs;
        public List<Image> heartUIsImage;
        public int maxHealth;


        private void Start() {
            heartUIs = FindObjectsOfType<HeartUI>();

            for(int i = 0 ; i < heartUIs.Length; i++)
            {
                for(int j = 0 ; j <heartUIs.Length; j++)
                {
                    if(heartUIs[j].index == i) heartUIsImage.Add(heartUIs[j].transform.GetComponent<Image>());
                }
            }        
        }

        public void SetMaxHealth(int _maxHealth)
        {
            maxHealth = _maxHealth;
        }

        public void UpdateHealthUI(int currHealth)
        {
            int healthPerHeart = maxHealth / heartUIsImage.Count;

            int healthCache = currHealth;
            for(int i = 0 ; i < heartUIsImage.Count; i++)
            {
                if(healthCache >= healthPerHeart)
                {
                    healthCache -= healthPerHeart;
                    heartUIsImage[i].fillAmount = 1f;
                }
                else
                {
                    heartUIsImage[i].fillAmount = healthCache / (float)healthPerHeart;
                    healthCache = 0;
                }
                
            }
        }        
    }
}