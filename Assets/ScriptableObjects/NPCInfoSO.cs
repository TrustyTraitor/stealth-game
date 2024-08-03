using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPCInfoSO", menuName = "ScriptableObjects/NPC/NPCInfoSO")]
public class NPCInfoSO : ScriptableObject
{
    [field: SerializeField]
    public int maxHealth { get; private set; } = 100;


    [field: SerializeField, Tooltip("This value determines the threshold for an NPC becoming alerted"), Header("NPC Behaviour")]
    public float maxSuspicion { get; private set; } = 100f;

    [field: SerializeField]
    public float suspicionResetTime { get; private set; } = 1f;

    [field: SerializeField, Tooltip("How often the entity's suspicion decreases after losing sight of target")]
    public float suspicionFallOffRate { get; private set; } = 0.1f;

    [field: SerializeField, Tooltip("This is the delay amount for the onAlertAfterDelay which triggers after the NPC is alerted.")]
    public float alertDelay { get; private set; } = 2f;

    [field: SerializeField, Tooltip("How long will the NPC Idle in one location before going back to patrol.")]
    public float IdleTime { get; private set; } = 30f;

    [field: SerializeField, Tooltip("How often the path finding is updated.")]
    public float pathUpdateDelay { get; private set; } = 0.2f;


    [field: SerializeField, Tooltip("How often the NPC will recheck their vision"), Header("NPC Vision")]
    public float visionUpdateDelay { get; private set; } = 0.05f;

    [field: SerializeField, Tooltip("How far away the player/suspcious activity can be seen")]
    public float viewDistance { get; private set; } = 20f;

    [field: SerializeField, Tooltip("The angle at which the player/suspicious activity can be seen")]
    public float viewAngle { get; private set; } = 75f;

    [field: SerializeField]
    public LayerMask layerMask { get; private set; }

    [field: SerializeField, Header("Weapon Info")]
    public float AttackSpeed { get; private set; } = 1.5f;
    [field: SerializeField]
    public int AttackDamage { get; private set; }  = 10;
}
