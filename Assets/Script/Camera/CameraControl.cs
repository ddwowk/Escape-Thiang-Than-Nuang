using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class CameraControl : MonoBehaviour
{
    private Vector2 _mousePosition;
    private float _screenWidthSize;
    [SerializeField] private float _checkDistance, _cameraMoveSpeed;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _roomTransform;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void Update()
    {
        PlanCamera(CheckMouse());
    }
    private void init()
    {
        _checkDistance = 5f;
        _cameraMoveSpeed = 10f;
    }
    private Vector2 CheckMouse()
    {
        _mousePosition = Input.mousePosition;
        _screenWidthSize = Screen.width;
        Vector2 direction = Vector2.zero;
        if (_mousePosition.x <= (0 + _checkDistance))
        {
            direction.x = -1;
        }
        else if (_mousePosition.x >= (_screenWidthSize - _checkDistance))
        {
            direction.x = 1;
        }
        return direction;
  
    }
    private void PlanCamera(Vector2 direction)
    {
        Camera _cam = Camera.main;
        Vector2 bottomLeft = _cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = _cam.ViewportToWorldPoint(new Vector2(1, 1));
        float cameraLeft = bottomLeft.x;
        float cameraRight = topRight.x;

        Renderer renderer = _roomTransform.GetComponent<SpriteRenderer>();

        Bounds roomBounds = renderer.bounds;

        float roomLeft = roomBounds.min.x;
        float roomRight = roomBounds.max.x;
        if (roomLeft <= cameraLeft && direction.x == -1)
        {
            gameObject.transform.Translate(direction * _cameraMoveSpeed * Time.deltaTime);
        }
        else if(roomRight >= cameraRight && direction.x == 1)
        {
            gameObject.transform.Translate(direction * _cameraMoveSpeed * Time.deltaTime);
        }
    }
    public void FadeCamera()
    {
        StartCoroutine(FadeInAndOut());
    }
    private IEnumerator FadeInAndOut()
    {
   
        yield return StartCoroutine(Fade(0, 2));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Fade(2, 0));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }

}
