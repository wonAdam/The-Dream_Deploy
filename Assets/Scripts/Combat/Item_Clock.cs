using System.Collections;
using System.Collections.Generic;
using ADAM.UI;
using UnityEngine;

namespace ADAM.Combat
{
    public class Item_Clock : MonoBehaviour
    {
        [SerializeField] float timeReduceAmount = 10f;
        [SerializeField] float disappearSec = 10f;
        [SerializeField] float blinkingStartSec = 7f; 

        float crrTikTok = 0f;
        Timer timer;

        private void Start() {
            timer = FindObjectOfType<Timer>();
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
                timer.ReduceTime(timeReduceAmount);
                Destroy(gameObject);
            }
        }
    }
}

