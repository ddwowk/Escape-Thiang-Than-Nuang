using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private float playerAnxiety, playerAnxietyMax;
    private int actionLevel = 0;
    private int _time = 0;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _endUI;
    public int ActionLevel { get => actionLevel; set => actionLevel = value; }

    private void Init(int maxAnxiety)
    {
        playerAnxietyMax = maxAnxiety;
    }
    private void Start()
    {
        Init(100);
    }
    private void FixedUpdate()
    {
        
        playerAnxiety += 0.01f * ActionLevel;
        Debug.Log(playerAnxiety);
        if (playerAnxiety >= playerAnxietyMax)
        {
            Debug.Log("Game Over");
        }
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(150);
        _time++;
        if (_time >= 6)
        {
            CheckWinCondition();
            _endUI.SetActive(true);
        }
    }
    public void CheckWinCondition()
    {
        if (_time == 6)
        {
            _text.text = "Win";
        }
        else
        {
            _text.text = "Lose";
        }
        
    }
    
}
