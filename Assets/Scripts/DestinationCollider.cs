using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCollider : MonoBehaviour
{
    [SerializeField] private Transform[] nextDestinations;
    
    public Transform[] GetNextDestinations()
    {
        return nextDestinations;
    }
}
