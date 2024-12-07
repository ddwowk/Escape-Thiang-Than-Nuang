using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInteract : InteracBase
{
    public override void OnclickObject()
    {
 
        StartCoroutine(Delay(2));
        Camera.FadeCamera();
        Debug.Log("Click");
    }
}
