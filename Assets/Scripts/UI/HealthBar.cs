using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ADAM.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Image healthInner;


        public void SetHealthBarUI(float percent)
        {
            healthInner.fillAmount = percent;
        }
    }
}
