using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectSuspicion : MonoBehaviour
{
    [SerializeField]
    public float standingSuspicion;

    public float baseSuspicion { get; private set; }

    [SerializeField]
    private float suspicion;

    [field: SerializeField]
    public Transform detectionNode { get; private set; }

    public float Suspicion
    {  
        get { return suspicion; }
        set { suspicion = value; }
    }

    private void Start()
    {
        baseSuspicion = suspicion;
    }

    private void Awake()
    {
        Assert.IsNotNull(detectionNode);
    }
}
