using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Player/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private int totalMoney;
    public int TotalMoney 
    { 
        get { return totalMoney; }
        private set
        { 
            totalMoney = value;
            onTotalMoneyUpdate?.Invoke();
        }
    }
    public event Action onTotalMoneyUpdate;


    [SerializeField]
    private int money;
    public int Money { 
        get { return money; } 
        set 
        {
            money = value;
            onMoneyUpdate?.Invoke();
        } 
    }
    public event Action onMoneyUpdate;


    [SerializeField]
    private int keyCardCount;
    public int KeyCardCount
    {
        get { return keyCardCount; }
        set
        {
            keyCardCount = value;
            onKeyCardUpdate?.Invoke();
            Debug.Log($"Keycards: {keyCardCount}");
        }
    }
    public event Action onKeyCardUpdate;


    private void OnDisable()
    {
        TotalMoney += Money;
        Money = 0;
        Debug.Log($"TotalMoney: {TotalMoney}");
    }

}
