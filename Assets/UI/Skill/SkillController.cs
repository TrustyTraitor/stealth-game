using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillController : MonoBehaviour
{
    [SerializeField]
    PlayerSkills skills;

    [SerializeField]
    InventorySO inventory;

    [SerializeField]
    Button incBtn;

    [SerializeField]
    Button decBtn;

    [SerializeField]
    TMP_Text label;

    [SerializeField]
    TMP_Text pointsLabel;

    [SerializeField]
    Skills skill;

    // Start is called before the first frame update
    void Start()
    {
        label.text = $"$ {skills.skillCost}";
        pointsLabel.text = $"{skills.GetSkillPointNum(skill)}";

        incBtn.onClick.AddListener( () => {
            if (inventory.TotalMoney >= skills.skillCost && 
                (inventory.PlayerLevel > skills.TotalPointsSpent())
                ) {
                inventory.TotalMoney -= skills.skillCost;
                skills.AlterSkillPoints(skill, 1);
                pointsLabel.text = $"{skills.GetSkillPointNum(skill)}";
            }
        } );

        decBtn.onClick.AddListener( () => {
            skills.AlterSkillPoints(skill, -1);
            pointsLabel.text = $"{skills.GetSkillPointNum(skill)}";
        } );
    }

}
