using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AgentController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private CarChecker carChecker;
    public Transform[] destinations;
    public NavMeshAgent agent;

    private float waitingTime = 1.5f;
    
    void OnEnable()
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
        yield return new WaitForSeconds(waitingTime);
        int randNum;
        if (destinations.Length == 1) 
            randNum = 0;
        else 
            randNum = Random.Range(0, destinations.Length);

        agent.SetDestination(destinations[randNum].position);
        animator.SetInteger("ControllerNPC", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DestinationCollider>() != null)
        {
            animator.SetInteger("ControllerNPC", 0);
            Debug.Log("Colided");
            carChecker.isCrosswalking = false;
            destinations = other.GetComponent<DestinationCollider>().GetNextDestinations();
            StartCoroutine(ChooseDestination());
        }
        else if(other.GetComponent<CrosswalkDestination>() != null && !carChecker.isCrosswalking)
        {
            animator.SetInteger("ControllerNPC", 0);
            Debug.Log("Crosswalk touched!");
            carChecker.isCrosswalking = true;
            CrosswalkDestination destination = other.GetComponent<CrosswalkDestination>();
            destinations = destination.GetCrosswalkDestination();

            agent.enabled = false;
            transform.LookAt(destination.crosswalkTarget);
            agent.enabled = true;
        }
    }
}
