using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private CarChecker carChecker;
    public Transform[] destinations;
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        carChecker = GetComponent<CarChecker>();
        StartCoroutine(ChooseDestination());
    }
    //private void Update()
    //{
    //    if (agent.isStopped && destinations != null)
    //    {
    //        StartCoroutine(ChooseDestination());
    //    }
    //}

    public IEnumerator ChooseDestination()
    {
        Debug.Log("Destination choosed");
        yield return new WaitForSeconds(1);
        int randNum;
        if (destinations.Length == 1) 
            randNum = 0;
        else 
            randNum = Random.Range(0, destinations.Length);

        agent.SetDestination(destinations[randNum].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DestinationCollider>() != null)
        {
            carChecker.isCrosswalking = false;
            destinations = other.GetComponent<DestinationCollider>().GetNextDestinations();
            StartCoroutine(ChooseDestination());

        }
        else if(other.GetComponent<CrosswalkDestination>() != null && !carChecker.isCrosswalking)
        {
            Debug.Log("Crosswalk touched!");
            carChecker.isCrosswalking = true;
            CrosswalkDestination destination = other.GetComponent<CrosswalkDestination>();
            destinations = destination.GetCrosswalkDestination();
        }
    }
}
