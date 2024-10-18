using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarChecker : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform otherPart;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            agent.SetDestination(transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            agent.SetDestination(otherPart.position);
        }
    }
}
