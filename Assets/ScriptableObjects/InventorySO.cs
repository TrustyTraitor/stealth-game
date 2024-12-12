using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Player/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField, Header("Money")]
    private int totalMoney;
    public int TotalMoney 
    { 
        get { return totalMoney; }
        set
        { 
            totalMoney = value;
            onTotalMoneyUpdate?.Invoke();
        }
    }
    public event Action onTotalMoneyUpdate;


    [SerializeField, Tooltip("Temporary storage. Money is moved to totalMoney after heist completion.")]
    private int money;
    public int Money { 
        get { return money; } 
        set 
        {
            money = value;
            onMoneyUpdate?.Invoke();
        } 
    }
    public event Action onMoneyUpdate;

    private int calculateLevel(int xp)
    {
        int level = (int)(xp / 25000);

        return level;
    }

    [SerializeField, Tooltip("This is used for keeping track of total Xp that has been earned by finishing a heist."), Header("XP & Level")]
    private int totalXp = 0;
    public int TotalXp
    {
        get { return totalXp; }
        set
        {
            totalXp = value;

            playerLevel = calculateLevel(totalXp);
        }
    }

    [SerializeField, Tooltip("Temporary storage for Xp that could be earned if the heist is finished.")]
    private int xpEarned;
    public int XpEarned
    {
        get { return xpEarned; }
        set
        {
            xpEarned = value;
        }
    }

    [SerializeField]
    private int playerLevel;
    public int PlayerLevel
    {
        get { return playerLevel; }
        set
        {
            playerLevel = value;
            onLevelUpdate?.Invoke();
        }
    }
    public event Action onLevelUpdate;

    [SerializeField, Header("Heist Items")]
    private int keyCardCount;
    public int KeyCardCount
    {
        get { return keyCardCount; }
        set
        {
            keyCardCount = value;
            onKeyCardUpdate?.Invoke();
            Debug.Log($"Keycards: {keyCardCount}");
        }
    }
    public event Action onKeyCardUpdate;

    //private void OnDisable()
    //{
    //    TotalMoney += Money;
    //    Money = 0;

    //    TotalXp += xpEarned;
    //    xpEarned = 0;

    //    Debug.Log($"TotalMoney: {TotalMoney}");
    //}

}
