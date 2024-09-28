using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraContext
{
    public MonoBehaviour parentObj { get; private set; }
    public bool isAlerted = false;
    public NPCInfoSO info { get; private set; }

    public Transform[] patrolPoints { get; private set; }
    public Animator animator { get; private set; }

    public NPCVisionN vision { get; private set; }

    public AudioSource audioSource { get; private set; }
    
    public HealthComponent healthComponent { get; private set; }

    public bool isDisabled { get; set; }

    public CameraContext(MonoBehaviour gameObject, NPCInfoSO info, Animator anim, NPCVisionN vision, AudioSource audioSource, HealthComponent hc, bool isDisabled)
    {
        this.info = info;
        this.parentObj = gameObject;
        this.animator = anim;
        this.vision = vision;
        this.audioSource = audioSource;
        this.healthComponent = hc;
        this.healthComponent.enabled = isDisabled;
    }
}
