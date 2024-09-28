using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(NPCVisionN))]
public class CameraBrain : StateManager<CameraBrain.CameraStates>
{
    public enum CameraStates
    {
        Scanning,
        Disabled,
        Destroyed
    }

    [SerializeField]
    private NPCInfoSO info;

    public CameraContext context { get; private set; }
    private NPCSuspicionHandler suspicionHandle;
    private Animator animator;
    private NPCVisionN vision;
    private AudioSource audioSource;
    private HealthComponent healthComponent;

    public CameraControlSO cameraControl;
    public PlayerDetectedAlert playerAlerting;

    [field: SerializeField, Tooltip("Sets a camera to a group. When a camera disable event is triggered, only disables the specified group.")]
    public uint cameraGroup { get; private set; } = 1;

    [SerializeField]
    private bool isDisabled = false;
    [Tooltip("Determines if the camera is disabled on level load")]
    public bool IsDisabled { 
        get { 
            return isDisabled; 
        } 
        set { 
            isDisabled = value; 
            context.isDisabled = IsDisabled; 
        } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        vision = GetComponent<NPCVisionN>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();

        context = new CameraContext(this, info,  animator, vision, audioSource, healthComponent, IsDisabled);
        suspicionHandle = GetComponent<NPCSuspicionHandler>();

        suspicionHandle.onAlertAfterDelay += PlayerHasBeenSeen;
        playerAlerting.onPlayerAlert += PlayerGlobalAlert;

        cameraControl.onCameraGroupDisable += DisableSelf;
        cameraControl.onCameraGroupEnable += EnableSelf;

        InitStates();
    }

    private void OnDisable()
    {
        suspicionHandle.onAlertAfterDelay -= PlayerHasBeenSeen;
        playerAlerting.onPlayerAlert -= PlayerGlobalAlert;

        cameraControl.onCameraGroupDisable -= DisableSelf;
        cameraControl.onCameraGroupEnable -= EnableSelf;
    }

    private void InitStates()
    {
        States.Add(CameraStates.Scanning, new ScanningState(context, CameraStates.Scanning));
        States.Add(CameraStates.Disabled, new DisabledState(context, CameraStates.Disabled));
        States.Add(CameraStates.Destroyed, new DestroyedState(context, CameraStates.Destroyed));

        CurrentState = States[CameraStates.Scanning];
    }

    public void PlayerHasBeenSeen()
    {
        context.isAlerted = true;

        playerAlerting.onPlayerAlert -= PlayerGlobalAlert;
        playerAlerting.AlertListeners();
    }

    public void PlayerGlobalAlert()
    {
        context.isAlerted = true;
    }

    public void DisableSelf(int group)
    {
        if (cameraGroup == group)
            IsDisabled = true;

    }

    public void EnableSelf(int group)
    {
        if (cameraGroup == group)
            IsDisabled = false;
    }
}
