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
                    Debug.Log("TriggerEnter " + gameObject.name);
                    // if it's projectile then dissapear
                    if(this.gameObject.tag == "Projectile")
                    {
                        other.GetComponent<Health>().PushedBack(transform.position);
                        Destroy(gameObject);
                    }
                        

                    // or it's enemy then do something else

                }
            }
        }

    }
}
