using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float playerAnxiety, playerAnxietyMax;
    private int actionLevel = 0;
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
    
}
