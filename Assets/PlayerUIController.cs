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
    public GameObject GameOverMenu;

    public HealthComponent Health;

    public enum OpenMenu {
        None,
        Menu,
        Skills,
        Heist,
        GameOver
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
                SetUIMode(ref HeistMenu, false);
                SetUIMode(ref GameOverMenu, false);

                SetUIMode(ref Hud, true);
            }
            else if (value == OpenMenu.Menu)
            {
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref HeistMenu, false);
                SetUIMode(ref GameOverMenu, false);

                SetUIMode(ref GameMenu, true, true);
            }
            else if (value == OpenMenu.Skills)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref HeistMenu, false);
                SetUIMode(ref GameOverMenu, false);

                SetUIMode(ref SkillsMenu, true, true);
            }
            else if (value == OpenMenu.Heist)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref GameOverMenu, false);

                SetUIMode(ref HeistMenu, true, true);
            }
            else if (value == OpenMenu.GameOver)
            {
                SetUIMode(ref GameMenu, false);
                SetUIMode(ref Hud, false);
                SetUIMode(ref SkillsMenu, false);
                SetUIMode(ref HeistMenu, false);

                SetUIMode(ref GameOverMenu, true, true);
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
        Health.onZeroHealth += OnPlayerDeath;
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Health.onZeroHealth -= OnPlayerDeath;
    }

    public void OnPlayerDeath()
    {
        Time.timeScale = 0;
        OpenUI(OpenMenu.GameOver);
    }

    public void OpenUI(OpenMenu menu)
    {
        this.CurrentMenu = menu;
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
