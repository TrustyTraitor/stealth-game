using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    Button restartHeistBtn;

    [SerializeField]
    Button quitHeistBtn;

    [SerializeField]
    Button exitButton;

    [SerializeField]
    public InventorySO inventory;

    private PlayerUIController UIController;

    private void Start()
    {
        UIController = GetComponentInParent<PlayerUIController>();

        this.restartHeistBtn.onClick.AddListener(() => {
            inventory.Money = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
