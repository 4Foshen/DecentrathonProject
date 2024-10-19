using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField] private GameObject[] npcs;

    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        SpawnAllNPCs();
    }

    private void SpawnAllNPCs()
    {
        ShuffleSpawnPoints();

        for (int i = 0; i < npcs.Length; i++)
        {
            if (i < spawnPoints.Length)
            {
                Instantiate(npcs[i], spawnPoints[i].position, npcs[i].transform.rotation);
            }
        }
    }

    private void ShuffleSpawnPoints()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }
    }
}
