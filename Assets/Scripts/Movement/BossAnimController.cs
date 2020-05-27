using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimController : MonoBehaviour
{
    private Animator myAnim;


    private void Start() {
        myAnim = GetComponent<Animator>();
    }


    public void UpdateAnimState(Vector2 dir)
    {

            if(dir.magnitude < Mathf.Epsilon)
            {
                myAnim.SetInteger("XDir", 0);
                return;
            }
            
            float angle = Vector2.SignedAngle(Vector2.right, dir);
            if(angle/90f > -0.5f && angle/90f < 0.5f) // right
            {
                myAnim.SetInteger("XDir", 1);
            }
            else if(angle/90f > 0.5f && angle/90f < 1.5f) // up
            {       
                myAnim.SetInteger("XDir", 0);

            }
            else if((angle/90f > 1.5f && angle/90f < 2f) || (angle/90f >= -2f && angle/90f < -1.5f)) // left
            {
    
                myAnim.SetInteger("XDir", -1);
            }
            else if(angle/90f < -0.5f && angle/90f > -1.5f) // down
            {       
                myAnim.SetInteger("XDir", 0);            
            }




    }
}
