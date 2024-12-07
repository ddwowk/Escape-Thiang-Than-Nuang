using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCurInteract : InteracBase
{
    [SerializeField] private DoorInteract _curClose;
    public override void OnclickObject()
    {
        PlayerState playerState = PlayerState.GetComponent<PlayerState>();
        base.OnclickObject();
        Debug.Log(IsActive);
        if (IsActive)
        {
            playerState.ActionLevel++;
        }
        else
        {
            playerState.ActionLevel--;
        }
    }
    public void OnclickBack()
    {
        StartCoroutine(Delay(2));
        Camera.FadeCamera();
    }
    public override IEnumerator Delay(float time)
    {
        WindowInteract interact = Botton.GetComponent<WindowInteract>();
        interact.IsActive = !interact.IsActive;
        IsActive = !IsActive;
        _curClose.IsActive = true;
        _curClose.OnclickObject();
        return base.Delay(time);
    }
}
