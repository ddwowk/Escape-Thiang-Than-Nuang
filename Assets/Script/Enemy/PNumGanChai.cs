using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNumGanChai : BaseEnemy
{
    [SerializeField] private GameObject _pcEvent;
    [SerializeField] private Button _button;
    private bool _isPCClose = false;
    public override void EnemyEvent()
    {
        Debug.Log("Event");
        _pcEvent.SetActive(true);
        StartCoroutine(OnEvent());
        
    }
    private IEnumerator OnEvent()
    {
        yield return new WaitForSeconds(5);
        if (!_isPCClose )
        {
            Debug.Log("You Dead");
        }
        _onEvent = false;
    }
    public void ClickPC()
    {
        Debug.Log("Click_PC");
        _pcEvent.SetActive(false);
        _isPCClose = true;
    }
}
