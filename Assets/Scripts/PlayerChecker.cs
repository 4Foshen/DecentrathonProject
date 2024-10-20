using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChooseAction();
        }
    }
    private void ChooseAction()
    {
        Debug.Log("Touch player");
        int randNum = Random.Range(0, clips.Length + 4);

        if(randNum <= clips.Length - 1)
        {
            PlaySound(randNum);
        }
    }
    private void PlaySound(int num)
    {
        audioSource.clip = clips[num];
        audioSource.Play();
    }
}
