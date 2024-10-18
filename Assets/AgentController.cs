using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private int previousNum;
    private NavMeshAgent agent;
    public Transform[] destination;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChooseDestination();
    }

    void Update()
    {
        
    }
    public void ChooseDestination()
    {
        int randNum = Random.Range(0, destination.Length);
        while(previousNum == randNum)
        {
           randNum = Random.Range(0, destination.Length);
        }

        previousNum = randNum;
        agent.SetDestination(destination[randNum].position);
    }
}
