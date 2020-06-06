using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Combat
{
    public class Item_Pencil : MonoBehaviour
    {
        [SerializeField] Sprite[] sprites;
        [SerializeField] AudioClip obtainSound;
        [SerializeField] int pencilObtainCount = 5;
        [SerializeField] float disappearSec = 10f;
        [SerializeField] float blinkingStartSec = 7f; 

        float crrTikTok = 0f;        

        private void Start() {
            int rand = Random.Range(0,sprites.Length);
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[rand];
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
                other.GetComponent<Shooter>().ObtainPencil(pencilObtainCount);
                Destroy(gameObject);
            }
        }
    }
}

