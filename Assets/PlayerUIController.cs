using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerUIController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject Hud;
    public GameObject SkillsMenu;
    public GameObject GameMenu;

    public enum OpenMenu {
        None,
        Menu,
        Skills
    }

    private OpenMenu currentMenu = OpenMenu.None;
    public OpenMenu CurrentMenu {  
        get { return currentMenu; }  
        set {
            currentMenu = value;

            if (value == OpenMenu.None)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref Hud, true);
            }
            else if (value == OpenMenu.Menu)
            {
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref GameMenu, true, true);
            }
            else if (value == OpenMenu.Skills) 
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref SkillsMenu, true, true);
            }
        } 
    }

    void SetUIMode(ref GameObject ui, bool visibility, bool isInteractable = false) {
        ui.SetActive(visibility);
        gameManager.IsInteractingWithUI = isInteractable;
    }

    private void Start()
    {
        this.CurrentMenu = this.currentMenu;
    }

    void Update()
    {
        
        if (this.currentMenu == OpenMenu.None && 
            Input.GetButtonDown("SkillsMenu"))
        {
            this.CurrentMenu = OpenMenu.Skills;

        } else if ( this.currentMenu == OpenMenu.Skills && 
            ( Input.GetButtonDown("SkillsMenu") || Input.GetButtonDown("Cancel")) )
        {
            this.CurrentMenu = OpenMenu.None;

        } else if ( this.currentMenu == OpenMenu.None && Input.GetButtonDown("Cancel"))
        {
            this.CurrentMenu = OpenMenu.Menu;

        } else if (this.currentMenu == OpenMenu.Menu && Input.GetButtonDown("Cancel")) 
        {
            this.CurrentMenu = OpenMenu.None;
        }
    }
}
