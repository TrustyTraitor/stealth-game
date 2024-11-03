using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIupdate : MonoBehaviour
{
    public InventorySO inventory;
    public TMP_Text levelLabel;

    private void Awake()
    {
        if (inventory != null)
        {
            inventory.onMoneyUpdate += OnMoneyUpdate;
            levelLabel.text = $"Level: {inventory.PlayerLevel}";
        }
    }

    private void OnMoneyUpdate()
    {
        if (inventory != null)
        {
            levelLabel.text = $"Level: {inventory.PlayerLevel}";
        }
    }
}
