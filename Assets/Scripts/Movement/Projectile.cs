using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Movement
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float destroyAfterFloorCollision = 3f;
        [SerializeField] float speed = 7f;
        [SerializeField] Sprite[] spriteVariations = null;
        Rigidbody2D myRb;
        float dir = 0f;
        bool velocityEnabled = true;
        public List<Floor> floors = new List<Floor>();


        private void Start() {
            myRb = GetComponent<Rigidbody2D>();
            Floor[] floorsTmp = FindObjectsOfType<Floor>();

            for(int i = 0 ; i < floorsTmp.Length; i++)
            {
                for(int j = 0; j < floorsTmp.Length; j++)
                {
                    string floorLayerName = "Floor " + (i+1).ToString();
                    if(floorsTmp[j].gameObject.layer == LayerMask.NameToLayer(floorLayerName))
                        floors.Add(floorsTmp[j]);
                }
            }
            SetRandomSprite();
            SetDir();
            SetRandomProjType();
            SetRandomCollisionFloor();
        }

        private void Update() {
            if(velocityEnabled)
                ShootSelf();
        }

        private void SetRandomSprite()
        {
            int index = Random.Range(0, spriteVariations.Length);
            GetComponent<SpriteRenderer>().sprite = spriteVariations[index];
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


            Debug.Log(LayerMask.NameToLayer("Floor 4"));
            if(floors.Find(x=>{ return x.gameObject.layer == LayerMask.NameToLayer("Floor 4"); }).transform.position.y >= transform.position.y)
            {
                myRb.gravityScale = 0f; return;
            }

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
            if(myRb.gravityScale < Mathf.Epsilon) { gameObject.layer = LayerMask.NameToLayer("Projectile 0"); return; }

            List<int> possibleFloors = new List<int>();
            for(int i = 0 ; i < floors.Count; i++)
            {
                if(transform.position.y > floors[i].transform.position.y)
                    possibleFloors.Add(i);
            }

            if(possibleFloors.Count < 1)
            {
                myRb.gravityScale = 0f;
                gameObject.layer = LayerMask.NameToLayer("Projectile 0"); return;            
            }

            int rand = Random.Range(0, possibleFloors.Count);
            string projLayerName = "Projectile " + (possibleFloors[rand]+1).ToString();

            gameObject.layer = LayerMask.NameToLayer(projLayerName);

        }

        private void ShootSelf()
        {
            myRb.velocity = new Vector2(50f * speed * dir * Time.deltaTime, myRb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Floor")
            {
                if(GetComponent<Animator>() != null)
                {
                    GetComponent<Animator>().enabled = false;
                }
                velocityEnabled = false;
                Destroy(gameObject, destroyAfterFloorCollision);
            }
        }
    }
}
