using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalungChang : BaseEnemy
{
    [SerializeField] private GameObject[] _statePosition;
    [SerializeField] private GameObject _currentRoom;
    [SerializeField] private DoorInteract _dooInteract;
    public override void EnemyEvent()
    {
        Debug.Log("OnChang");
        if (EnemyState < 3)
        {
            EnemyState++;
            Debug.Log(EnemyState);
            MoveCheck(EnemyState);
        }
        else
        {
            EnemyState = 0;
            MoveCheck(EnemyState);
        }
    }
    private void MoveCheck(int state)
    {
        if (_currentRoom != null && state - 1 >= 0)
        {
            _currentRoom.SetActive(false);
            _currentRoom = _statePosition[state - 1];
            _currentRoom.SetActive(true);
        }
        else if (_currentRoom == null)
        {
            _currentRoom = _statePosition[state - 1];
            _currentRoom.SetActive(true);
        }
        else if (state >= 3)
        {
            StartCoroutine(WaitForjupm());
        }
        StartCoroutine(Delay(5));
    }
    public IEnumerator WaitForjupm()
    {
        yield return new WaitForSeconds(5);
        if(!_dooInteract.IsActive) 
        {
            Debug.Log("Dead");
        }
    }
    public IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        _onEvent = false;
    }
}
