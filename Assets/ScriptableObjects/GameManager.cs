using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager")]
public class GameManager : ScriptableObject
{
    [SerializeField]
    private bool isInteractingWithUI = false;
    public bool IsInteractingWithUI {
        get { return isInteractingWithUI; }
        set
        {
            isInteractingWithUI = value;

            if ( isInteractingWithUI )
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        } 
    }

    private void OnEnable()
    {
        this.isInteractingWithUI = false;
    }
}
