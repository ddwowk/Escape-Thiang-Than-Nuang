using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChangeControl : MonoBehaviour
{
    [SerializeField] private GameObject _roomChange, _noiseScreen, _CCTVmenager;
    public void CameraClick()
    {
        CCTVColtroller cCTVColtroller = _CCTVmenager.GetComponent<CCTVColtroller>();
        StartCoroutine(CameraNoise(1f));
        _roomChange.SetActive(true);
        if (cCTVColtroller.CurrentCCTVRoom != _roomChange)
        cCTVColtroller.CurrentCCTVRoom.SetActive(false);
        cCTVColtroller.CurrentCCTVRoom = _roomChange;
    }
    private IEnumerator CameraNoise(float delay)
    {
        _noiseScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
        _noiseScreen.SetActive(false);
    }
}
