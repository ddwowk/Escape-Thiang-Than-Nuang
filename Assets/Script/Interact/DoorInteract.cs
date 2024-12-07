using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DoorInteract : InteracBase
{
    public override void OnclickObject()
    {
        PlayerState playerState = PlayerState.GetComponent<PlayerState>();
        base.OnclickObject();
        Debug.Log(IsActive);
        if (IsActive)
        {
            playerState.ActionLevel++;
        }
        else if(!IsActive)
        {
            playerState.ActionLevel --;
        }
    }
}
