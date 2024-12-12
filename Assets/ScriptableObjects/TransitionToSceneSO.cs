using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "TransitionToScene", menuName = "ScriptableObjects/TransitionToScene")]
public class TransitionToSceneSO : InteractActionSO
{
    [SerializeField]
    private string scene;

    public override void Execute(GameObject obj = null)
    {
        SceneManager.LoadScene(scene);
    }

    public void Transition()
    {
        this.Execute();
    }
}
