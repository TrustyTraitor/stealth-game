using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Skills
{
    WeaponDmg,
    Health,
    Shield,
    Stealth,
    MoveSpeed
};

[CreateAssetMenu(fileName = "PlayerSkills", menuName = "ScriptableObjects/PlayerSkills")]
public class PlayerSkills : ScriptableObject
{
    public int skillCost = 10000;
    
    [field: SerializeField, Header("Weapon Damage Skill modifiers")]
    public float weaponDamageMod { get; private set; } = 0.0f;
    public float wpnDmgPercent = 2.5f;
    public int wpnDmgPoints = 0;
    public int WpnDmgPoints
    {
        get { return wpnDmgPoints; }
        set {
            wpnDmgPoints = value;
            if (wpnDmgPoints < 0) wpnDmgPoints = 0;

            weaponDamageMod = ((float)wpnDmgPoints) * wpnDmgPercent;
        }
    }

    [field: SerializeField, Header("Health Skill modifiers")]
    public float healthMod { get; private set; } = 0.0f;
    public float healthPercent = 5.0f;
    public int healthPoints = 0;
    public int HealthPoints
    {
        get { return healthPoints; }
        set
        {
            healthPoints = value;
            if (healthPoints < 0) healthPoints = 0;

            healthMod = ((float)healthPoints) * healthPercent;
        }
    }


    [field: SerializeField, Header("Shield Skill modifiers")]
    public float shieldMod { get; private set; } = 0.0f;
    public float shieldPercent = 4.0f;
    public int shieldPoints = 0;
    public int ShieldPoints
    {
        get { return shieldPoints; }
        set
        {
            shieldPoints = value;
            if (shieldPoints < 0) shieldPoints = 0;

            shieldMod = ((float)shieldPoints) * shieldPercent;
        }
    }

    [field: SerializeField, Header("Stealth Skill modifiers")]
    public float stealthMod { get; private set; } = 0.0f;
    public float stealthPercent = 3.0f;
    public int stealthPoints = 0;
    public int StealthPoints
    {
        get { return stealthPoints; }
        set
        {
            stealthPoints = value;
            if (stealthPoints < 0) stealthPoints = 0;

            stealthMod = ((float)stealthPoints) * stealthPercent;
        }
    }

    [field: SerializeField, Header("Move Speed Skill modifiers")]
    public float moveSpeedMod { get; private set; } = 0.0f;
    public float moveSpeedPercent = 1.5f;

    public int moveSpeedPoints = 0;
    public int MoveSpeedPoints
    {
        get { return moveSpeedPoints; }
        set
        {
            moveSpeedPoints = value;
            if (moveSpeedPoints < 0) moveSpeedPoints = 0;

            moveSpeedMod = ((float)moveSpeedPoints) * moveSpeedPercent;
        }
    }

    public int TotalPointsSpent() {
        return wpnDmgPoints + healthPoints + shieldPoints + moveSpeedPoints + stealthPoints;
    }

    public int GetSkillPointNum(Skills skill) {
        switch (skill)
        {
            case Skills.WeaponDmg:
                return WpnDmgPoints;

            case Skills.Health:
                return HealthPoints;

            case Skills.Shield:
                return ShieldPoints;

            case Skills.Stealth:
                return StealthPoints;

            case Skills.MoveSpeed:
                return MoveSpeedPoints;
            default:
                return 0;
        }
    }

    public void AlterSkillPoints(Skills skill, int val) {
        switch (skill) {
            case Skills.WeaponDmg:
                WpnDmgPoints += val;
                break;

            case Skills.Health:
                HealthPoints += val;
                break;

            case Skills.Shield:
                ShieldPoints += val;
                break;

            case Skills.Stealth:
                StealthPoints += val;
                break;

            case Skills.MoveSpeed:
                MoveSpeedPoints += val;
                break;
        }
    }
}
