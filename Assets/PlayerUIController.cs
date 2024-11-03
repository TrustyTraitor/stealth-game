using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject SkillsMenu;

    void Update()
    {
        if (SkillsMenu.activeInHierarchy == false && Input.GetButtonDown("SkillsMenu"))
        {
            gameManager.IsInteractingWithUI = true;
            SkillsMenu.SetActive(true);

        } else if ( SkillsMenu.activeInHierarchy == true 
        && ( Input.GetButtonDown("SkillsMenu") || Input.GetButtonDown("Cancel")) )
        {
            gameManager.IsInteractingWithUI = false;
            SkillsMenu.SetActive(false);

        }
    }
}
