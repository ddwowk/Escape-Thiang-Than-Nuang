using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int _eventRate;
    private int _enemyState = 0;
    protected bool _onEvent = false;

    public int EnemyState { get => _enemyState; set => _enemyState = value; }

    private int RandomEvent()
    {
        int randomNum = Random.Range(0, 100);
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
    public abstract void EnemyEvent();
}
