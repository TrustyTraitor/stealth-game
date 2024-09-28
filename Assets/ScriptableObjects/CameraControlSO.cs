using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CameraControlSO", menuName = "ScriptableObjects/Environment/CameraController")]
public class CameraControlSO : ScriptableObject
{
    public Action<int> onCameraGroupEnable;
    public Action<int> onCameraGroupDisable;

    public void ToggleCameraGroupStatus(int group, bool status)
    {
        if (status)
        {
            onCameraGroupEnable?.Invoke(group);
        }
        else
        {
            onCameraGroupDisable?.Invoke(group);
        }
    }
}
