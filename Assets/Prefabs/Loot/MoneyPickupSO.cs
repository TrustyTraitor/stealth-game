using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyPickupSO", menuName = "ScriptableObjects/Pickups/Money")]
public class MoneyPickupSO : InteractActionSO
{
    [SerializeField]
    private int MoneyAmount = 0;

    [SerializeField, DisallowNull]
    private InventorySO inventory;

    public override void Execute(GameObject obj = null)
    {
        inventory.Money += MoneyAmount;
    }
}
