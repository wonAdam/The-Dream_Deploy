using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour
{
    public void SkipTrigger()
    {
        GetComponent<Animator>().SetTrigger("Skip");
    }
}