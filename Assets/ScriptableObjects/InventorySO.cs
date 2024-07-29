using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Player/Inventory")]
public class InventorySO : ScriptableObject
{
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
    

    public int KeyCardCount { 
        get { return KeyCardCount; } 
        set 
        { 
            KeyCardCount = value;
            onKeyCardUpdate?.Invoke();
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
