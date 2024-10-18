using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            StartCoroutine(DestinationCoroutine(other));
        }
    }
    IEnumerator DestinationCoroutine(Collider collider)
    {
        yield return new WaitForSeconds(3);
        collider.gameObject.GetComponent<AgentController>().ChooseDestination();
    }
}
