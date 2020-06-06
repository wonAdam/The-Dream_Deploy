using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Combat
{
    public class Item_ChocoBar : MonoBehaviour
    {
        [SerializeField] AudioClip obtainSound;
        [SerializeField] int healAmount = 2;
        [SerializeField] float disappearSec = 10f;
        [SerializeField] float blinkingStartSec = 7f; 
        float crrTikTok = 0f;

        private void Start() {
            Destroy(gameObject, disappearSec);
        }
        private void Update() {
            TikTok();
        }

        private void TikTok()
        {
            crrTikTok += Time.deltaTime;

            if(crrTikTok >= blinkingStartSec)
            {
                GetComponent<Animator>().SetBool("ThreeLeft", true);
            }
            if(crrTikTok >= disappearSec)
            {
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(obtainSound,new Vector2(0f,0f), 1f);
                other.GetComponent<Health>().Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}

