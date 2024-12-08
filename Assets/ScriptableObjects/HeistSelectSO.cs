using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeistSelectSO", menuName = "ScriptableObjects/HeistSelect")]
public class HeistSelectSO : InteractActionSO
{
    public override void Execute(GameObject obj = null)
    {
        var comp = obj.GetComponent<PlayerUIController>();
        comp.OpenUI(PlayerUIController.OpenMenu.Heist);
    }
}
