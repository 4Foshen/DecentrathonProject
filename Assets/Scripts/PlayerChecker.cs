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
        int randNum = Random.Range(0, clips.Length + 1 + 3);

        if(randNum <= clips.Length - 1)
        {
            PlaySound(randNum);
        }
        else if(randNum ==  clips.Length)
        {
            //Animation
        }
    }
    private void PlaySound(int num)
    {
        audioSource.clip = clips[num];
        audioSource.Play();
    }
}
