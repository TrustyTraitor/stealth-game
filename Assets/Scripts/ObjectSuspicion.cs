using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectSuspicion : MonoBehaviour
{
    [SerializeField]
    private float suspicion;

    [field: SerializeField]
    public Transform detectionNode { get; private set; }

    public float Suspicion
    {  
        get { return suspicion; }
        private set { suspicion = value; }
    }

    private void Awake()
    {
        Assert.IsNotNull(detectionNode);
    }
}
