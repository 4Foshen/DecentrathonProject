using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarChecker : MonoBehaviour
{
    private AgentController controller;

    [SerializeField] private LayerMask carLayer;
    [SerializeField] private float detectionRadius;
    public bool isCrosswalking;
    public bool isWaiting;


    private void Start()
    {
        controller = GetComponent<AgentController>();
    }
    private void Update()
    {
        if (isCrosswalking)
        {
            CheckForCars();
        }
    }
    public void CheckForCars()
    {
        Collider[] cars = Physics.OverlapSphere(transform.position, detectionRadius, carLayer);
        isWaiting = cars.Length > 0;
        Debug.Log(cars.Length);

        if (!isWaiting)
        {
            if (controller.agent.remainingDistance <= controller.agent.stoppingDistance)
            {
                StartCoroutine(controller.ChooseDestination());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
