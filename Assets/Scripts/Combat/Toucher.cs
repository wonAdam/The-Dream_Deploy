using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ADAM.Combat
{
    public class Toucher : MonoBehaviour
    {
        [SerializeField] int damage = 10;

        private void OnTriggerStay2D(Collider2D other) {
            if(other.GetComponent<Health>() != null && other.GetComponent<Health>().canBeDamaged() && other.tag == "Player" && gameObject.tag != "Pencil")
            {
                Attack(other);
            }
            else if(other.GetComponent<Health>() != null && other.GetComponent<Health>().canBeDamaged() && other.tag != "Player" && gameObject.tag == "Pencil")
            {
                Attack(other);
            }
        }

        public void Attack(Collider2D other)
        {
            if(other.GetComponent<Health>().TakeDamage(damage))
            {
                Debug.Log("TriggerEnter " + gameObject.name);
                // if it's projectile then dissapear
                if(this.gameObject.tag == "Projectile")
                {
                    PushBack(other.GetComponent<Rigidbody2D>());
                    Destroy(gameObject);
                }
                if(this.gameObject.tag == "Enemy")
                {
                    PushBack(other.GetComponent<Rigidbody2D>());
                }
                if(this.gameObject.tag == "Pencil")
                {
                    Destroy(gameObject);                
                }

            }        
        }

        public void PushBack(Rigidbody2D rb)
        {
            Vector2 dir = rb.transform.position - transform.position;
            rb.AddForce(dir * 200f);
        }
    }
}
