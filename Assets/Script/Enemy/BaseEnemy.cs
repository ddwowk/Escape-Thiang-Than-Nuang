using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int _eventRate;
    [SerializeField] private GameObject _winMenu,_jumpUI;
    [SerializeField] private PlayerState _playerState;
    private int _enemyState = 0;
    protected bool _onEvent = false;

    public int EnemyState { get => _enemyState; set => _enemyState = value; }
    public GameObject WinMenu { get => _winMenu; set => _winMenu = value; }
    public PlayerState PlayerState { get => _playerState; set => _playerState = value; }

    private int RandomEvent()
    {
        int randomNum = Random.Range(0, 100+1);
        return randomNum;
    }
    private void CheckEvent(int check)
    {
        Debug.Log("check");
        if(check <= _eventRate)
        {
            EnemyEvent();
            _onEvent = true;
        }
    }
    private void Start()
    {
        StartCoroutine(RunRandomEvent());
    }
    protected IEnumerator RunRandomEvent()
    {
        while (true)
        {
            if (!_onEvent)
            {
                yield return new WaitForSeconds(1); 
                CheckEvent(RandomEvent());
            }
            else
            {
                yield return null;
            }
        }
    }
    protected void JumpScare()
    {
        _jumpUI.SetActive(true);
    }
    public abstract void EnemyEvent();
}
