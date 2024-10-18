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

        int randNum = Random.Range(0, clips.Length);
        switch (randNum)
        {
            case 0:
                PlaySound(randNum);
                break;
            case 1:
                PlaySound(randNum);
                break;
            case 2:
                PlaySound(randNum);
                break;
            case 3:
                //Aniamtion;
                break;
            default:
                break;
        }
    }
    private void PlaySound(int num)
    {
        audioSource.clip = clips[num];
        audioSource.Play();
    }
}
