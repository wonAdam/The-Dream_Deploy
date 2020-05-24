using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ADAM.Combat
{
    public class Toucher : MonoBehaviour
    {
        [SerializeField] int damage = 10; 
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Player")
            {
                if(other.GetComponent<Health>().TakeDamage(damage))
                {
                    // if it's projectile then dissapear

                    // or it's enemy then do something else

                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Player")
            {
                if(other.transform.GetComponent<Health>().TakeDamage(damage))
                {
                    // if it's projectile then dissapear

                    // or it's enemy then do something else

                }
            }

            if(other.gameObject.tag == "Floor")
            {
                Destroy(gameObject, 3f);
            }        
        }
    }
}
