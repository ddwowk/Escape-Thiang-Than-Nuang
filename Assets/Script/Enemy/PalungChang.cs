using System.Collections;
using UnityEngine;

public class PalungChang : BaseEnemy
{
    [SerializeField] private GameObject[] _statePosition;
    [SerializeField] private GameObject _currentRoom;
    [SerializeField] private DoorInteract _dooInteract;

    public override void EnemyEvent()
    {
        Debug.Log("OnChang Event Triggered");

        if (EnemyState < _statePosition.Length)
        {
            EnemyState++;
            MoveToState(EnemyState);
        }
        else
        {
            EnemyState = 0;
            MoveToState(EnemyState);
        }
    }

    private void MoveToState(int state)
    {
        Debug.Log($"Moving to state {state}");

        if (_currentRoom != null)
        {
            _currentRoom.SetActive(false);
        }

        if (state < _statePosition.Length)
        {
            _currentRoom = _statePosition[state];
            _currentRoom.SetActive(true);
        }

        if (state == _statePosition.Length)
        {
            StartCoroutine(WaitForJump());
        }
        else
        {
            StartCoroutine(DelayNextEvent(5f));
        }
    }

    private IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(5f);

        if (!_dooInteract.IsActive)
        {
            JumpScare();
        }

        _onEvent = false;
    }

    private IEnumerator DelayNextEvent(float time)
    {
        yield return new WaitForSeconds(time);
        _onEvent = false;
    }
}
