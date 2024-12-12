using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    Button resumeBtn;

    [SerializeField]
    Button quitHeistBtn;

    [SerializeField]
    Button exitButton;

    private PlayerUIController UIController;

    public InventorySO inventory;

    private void Start()
    {
        UIController = GetComponentInParent<PlayerUIController>();

        this.resumeBtn.onClick.AddListener( () => {
            UIController.CurrentMenu = PlayerUIController.OpenMenu.None; 
        });

        this.quitHeistBtn.onClick.AddListener(() =>
        {
            inventory.Money = 0;
            SceneManager.LoadScene("Hideout");
        });

        this.exitButton.onClick.AddListener(() => {
            inventory.Money = 0;
            Debug.Log("Note! This Button does not work in the editor!");
            Application.Quit(); 
        });
    }
}
