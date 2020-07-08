using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincanvas : MonoBehaviour
{
    public void OnAnimationStart()
    {
        GetComponent<Animator>().ResetTrigger("NextScene");
    }
}
