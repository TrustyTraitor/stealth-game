using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        UIController = GetComponentInParent<PlayerUIController>();

        this.resumeBtn.onClick.AddListener( () => {
            UIController.CurrentMenu = PlayerUIController.OpenMenu.None; 
        });

        this.quitHeistBtn.onClick.AddListener( () => {
            Debug.Log("TODO!");
        });

        this.exitButton.onClick.AddListener(() => {
            Debug.Log("Note! This Button does not work in the editor!");
            Application.Quit(); 
        });
    }
}
