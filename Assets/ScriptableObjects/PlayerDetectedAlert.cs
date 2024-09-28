using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDetectedAlertSO", menuName = "ScriptableObjects/NPC/AlertEventBus")]
public class PlayerDetectedAlert : ScriptableObject
{
    public Action onPlayerAlert;
    public void AlertListeners() {
        onPlayerAlert?.Invoke();
    }
}
