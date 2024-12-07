using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class CCTVColtroller : MonoBehaviour
{
    [SerializeField] private GameObject _CCTVScreen, _CCTVProp, _cameraInScene, _currentCCTVRoom;
    [SerializeField] private Animator anim;
    public GameObject CurrentCCTVRoom { get => _currentCCTVRoom; set => _currentCCTVRoom = value; }
    private bool isCCTVOpen = false;

    private void Start()
    {
        anim = _CCTVProp.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCCTVOpen = !isCCTVOpen;
            CCTVManage();
        }
    }
    private void CCTVManage()
    {
        CameraControl cameraControl = _cameraInScene.GetComponent<CameraControl>();
        if (isCCTVOpen)
        {
            StartCoroutine(OpenDelay(0.7f));
            cameraControl.enabled = false;
        }
        else
        {
            StartCoroutine(OpenDelay(0));
            cameraControl.enabled = true;
        }
        anim.SetBool("open",isCCTVOpen);
    }
    private IEnumerator OpenDelay(float delay)
    {
        _CCTVProp.SetActive(true);
        yield return new WaitForSeconds(delay);
        _CCTVScreen.SetActive(isCCTVOpen);
        _cameraInScene.transform.position = new Vector3(0, 0, -10);
        if (isCCTVOpen)
        {
             _CCTVProp.SetActive(false);
        }
        if (_currentCCTVRoom != null && isCCTVOpen)
        {
            _currentCCTVRoom.SetActive(true);
        }
        else
        {
            _currentCCTVRoom.SetActive(false);
        }
    }
    
}
