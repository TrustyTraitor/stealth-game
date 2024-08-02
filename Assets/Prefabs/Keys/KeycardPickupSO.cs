using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "KeycardPickupSO", menuName = "ScriptableObjects/Pickups/Keycard")]
public class KeycardPickupSO : InteractActionSO
{
    [SerializeField, DisallowNull]
    private InventorySO inventory;


    public override void Execute(GameObject obj = null)
    {
        inventory.KeyCardCount += 1;
    }
}
