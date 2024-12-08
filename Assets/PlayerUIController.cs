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
    public GameObject HeistMenu;

    public enum OpenMenu {
        None,
        Menu,
        Skills,
        Heist
    }

    private OpenMenu currentMenu = OpenMenu.None;
    public OpenMenu CurrentMenu {  
        get { return currentMenu; }  
        set {
            Debug.Log("VAL HERE");
            currentMenu = value;

            if (value == OpenMenu.None)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref HeistMenu, false);

                SetUIMode(ref Hud, true);
            }
            else if (value == OpenMenu.Menu)
            {
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref HeistMenu, false);

                SetUIMode(ref GameMenu, true, true);
            }
            else if (value == OpenMenu.Skills)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref HeistMenu, false);

                SetUIMode(ref SkillsMenu, true, true);
            }
            else if (value == OpenMenu.Heist)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref SkillsMenu, false);

                SetUIMode(ref HeistMenu, true, true);
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

    public void OpenUI(OpenMenu menu)
    {
        this.CurrentMenu = menu;
        Debug.Log("here");
    }

    void Update()
    {
        
        if (this.currentMenu == OpenMenu.None && 
            Input.GetButtonDown("SkillsMenu"))
        {
            this.CurrentMenu = OpenMenu.Skills;

        } 
        else if ( this.currentMenu == OpenMenu.Skills && 
            ( Input.GetButtonDown("SkillsMenu") || Input.GetButtonDown("Cancel")) )
        {
            this.CurrentMenu = OpenMenu.None;

        } 
        else if ( this.currentMenu == OpenMenu.None && Input.GetButtonDown("Cancel"))
        {
            this.CurrentMenu = OpenMenu.Menu;

        } 
        else if (this.currentMenu == OpenMenu.Menu && Input.GetButtonDown("Cancel")) 
        {
            this.CurrentMenu = OpenMenu.None;
        }
        else if (this.currentMenu == OpenMenu.Heist && Input.GetButtonDown("Cancel"))
        {
            this.CurrentMenu = OpenMenu.None;
        }
    }
}
