using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class InteracBase : MonoBehaviour
{
    [SerializeField] private GameObject _interactObject, _playerState, _botton;
    [SerializeField] private CameraControl _camera;
    private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }
    public GameObject PlayerState { get => _playerState; set => _playerState = value; }
    public GameObject InteractObject { get => _interactObject; set => _interactObject = value; }
    public CameraControl Camera { get => _camera; set => _camera = value; }
    public GameObject Botton { get => _botton; set => _botton = value; }

    public virtual void OnclickObject()
    {
        IsActive = !IsActive;
        InteractObject.SetActive(IsActive);
    }
    public virtual IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        IsActive = !IsActive;
        if (IsActive)
        {
            Camera.enabled = false;
        }
        if (!IsActive)
        {
            Camera.enabled = true;
        }
        Camera.transform.position = new Vector3(0, 0, -10);
        InteractObject.SetActive(IsActive);
        Botton.SetActive(!IsActive);
    }
}
