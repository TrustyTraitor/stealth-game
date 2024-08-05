using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CompleteHeistUI : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private TMP_Text moneyText;

    [SerializeField]
    private InventorySO inventory;

    // Update is called once per frame
    void Update()
    {
        ui.SetActive(false);

        moneyText.text = $"${inventory.Money}";
        if (Input.GetButtonDown("ContinueHeist"))
        {
            SceneManager.LoadScene("Hideout");
        }
    }
}
