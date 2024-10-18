using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkDestination : MonoBehaviour
{
    [SerializeField] private Transform[] crosswalkDestination;

    public Transform[] GetCrosswalkDestination()
    {
        return crosswalkDestination;
    }
}
