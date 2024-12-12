using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    Button startBtn;

    [SerializeField]
    Button quitBtn;

    private void Start()
    {
        this.startBtn.onClick.AddListener( 
            () => { 
                StartGame(); 
            });

        this.quitBtn.onClick.AddListener(
            () => {
                QuitGame();
            });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Hideout");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
