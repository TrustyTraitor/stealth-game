using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveUpdater : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventory;

    [SerializeField]
    private TMP_Text text;

    private void Awake()
    {
        inventory.onMoneyUpdate += UpdateObjective;    
    }

    public void UpdateObjective()
    {
        if (inventory.Money >= 500000)
        {
            text.fontSize = 150;
            text.text = "Return to Hideout with your vehicle, or look for more loot.";
            inventory.onMoneyUpdate -= UpdateObjective;
        }
    }
}
