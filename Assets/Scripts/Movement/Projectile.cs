using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ADAM.Movement
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float destroyAfterFloorCollision = 3f;
        [SerializeField] float speed = 7f;
        Rigidbody2D myRb;
        float dir = 0f;
        bool velocityEnabled = true;


        private void Start() {
            myRb = GetComponent<Rigidbody2D>();
            SetDir();
            SetRandomProjType();
            SetRandomCollisionFloor();
        }

        private void Update() {
            if(velocityEnabled)
                ShootSelf();
        }

        private void SetDir()
        {
            if(transform.position.x < 0f) // right dir
            {
                dir = 1f;
            }
            else{ // left dir
                dir = -1f;
            }
        }
        private void SetRandomProjType()
        {
            int type = Random.Range(0,2);

            if(type == 0) // type == Straight
            {
                myRb.gravityScale = 0f;
            }
            else // type == Curve
            {
                myRb.gravityScale = 1f;

                float randVelocity = Random.Range(speed - 3f, speed + 3f);
                speed = randVelocity;
            }
        }
        
        private void SetRandomCollisionFloor()
        {
            if(myRb.gravityScale < Mathf.Epsilon) return;

            int rand = Random.Range(LayerMask.NameToLayer("Projectile 1"), LayerMask.NameToLayer("Projectile 4") + 1);

            gameObject.layer = rand;

        }

        private void ShootSelf()
        {
            myRb.velocity = new Vector2(50f * speed * dir * Time.deltaTime, myRb.velocity.y);
            // 50f * Vector2.right * speed * dir * Time.deltaTime; 
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Floor")
            {
                velocityEnabled = false;
                Destroy(gameObject, destroyAfterFloorCollision);
            }
        }
    }
}
