using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public InventorySO inventory;
    public TMP_Text moneyLabel;
    public TMP_Text totalMoneyLabel;

    private void Awake()
    {
        if (inventory != null)
        {
            inventory.onMoneyUpdate += OnMoneyUpdate;
            moneyLabel.text = $"$ {inventory.Money}";
            totalMoneyLabel.text = $"$ {inventory.TotalMoney}";
        }
    }

    private void OnMoneyUpdate()
    {
        if (inventory != null)
        {
            moneyLabel.text = $"$ {inventory.Money}";
            //totalMoneyLabel.text = $"$ {inventory.TotalMoney}";
        }
    }
}
