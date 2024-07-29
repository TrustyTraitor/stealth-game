using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int money;

    public int Money {
        get { return money; }
        set 
        {
            money = value;
            if (onMoneyUpdate != null) onMoneyUpdate();
        }
    }

    public delegate void OnMoneyUpdate();
    public event OnMoneyUpdate onMoneyUpdate;


}
