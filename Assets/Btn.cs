using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    [SerializeField] GameObject windowToOpenNClose;

    public void OnClick_Btn()
    {
        if (windowToOpenNClose.activeInHierarchy)
        {
            windowToOpenNClose.SetActive(false);
        }
        else
        {
            windowToOpenNClose.SetActive(true);
        }
    }
}

