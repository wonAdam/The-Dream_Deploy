using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Movement
{
    public class PlayerAnimController : MonoBehaviour
    {
        public enum DIRECTION{
            RIGHT, LEFT, UP, DOWN
        }
        DIRECTION currDir = DIRECTION.DOWN;
        Animator myAnim;
        [SerializeField] Transform gun;
        private void Start() {
            myAnim = GetComponent<Animator>();
        }
        public void UpdateAnimState(Vector2 dir)
        {
            if(dir.magnitude < Mathf.Epsilon)
            {
                myAnim.SetInteger("XDir", 0);
                myAnim.SetInteger("YDir", 0);     
                return;
            }
            
            float angle = Vector2.SignedAngle(Vector2.right, dir);
            if(angle/90f > -0.5f && angle/90f < 0.5f) // right
            {
                if(currDir != DIRECTION.RIGHT)
                {
                    currDir = DIRECTION.RIGHT; 
                    myAnim.SetTrigger("ChangeDir");     
                }
                myAnim.SetInteger("XDir", 1);
                myAnim.SetInteger("YDir", 0);     

                gun.localEulerAngles = new Vector3(0f,0f,0f);
                gun.localPosition = new Vector2(0.5f, 0f);
            }
            else if(angle/90f > 0.5f && angle/90f < 1.5f) // up
            {
                if(currDir != DIRECTION.UP)
                {
                    currDir = DIRECTION.UP; 
                    myAnim.SetTrigger("ChangeDir");     
                }            
                myAnim.SetInteger("XDir", 0);
                myAnim.SetInteger("YDir", 1);  

                gun.localEulerAngles = new Vector3(0f,0f,90f);
                gun.localPosition = new Vector2(0f, 0.5f);            
            }
            else if((angle/90f > 1.5f && angle/90f < 2f) || (angle/90f >= -2f && angle/90f < -1.5f)) // left
            {
                if(currDir != DIRECTION.LEFT)
                {
                    currDir = DIRECTION.LEFT; 
                    myAnim.SetTrigger("ChangeDir");     
                }            
                myAnim.SetInteger("XDir", -1);
                myAnim.SetInteger("YDir", 0);    

                gun.localEulerAngles = new Vector3(0f,0f,180f);
                gun.localPosition = new Vector2(-0.5f, 0f);                
            }
            else if(angle/90f < -0.5f && angle/90f > -1.5f) // down
            {
                if(currDir != DIRECTION.DOWN)
                {
                    currDir = DIRECTION.DOWN; 
                    myAnim.SetTrigger("ChangeDir");     
                }            
                myAnim.SetInteger("XDir", 0);
                myAnim.SetInteger("YDir", -1);  

                gun.localEulerAngles = new Vector3(0f,0f,-90f);
                gun.localPosition = new Vector2(0f, -0.5f);                 
            }
    
        }
    }
}
