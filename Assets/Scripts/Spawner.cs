using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] interactiveObjects;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < interactiveObjects.Length; i++)
        {
            int spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(interactiveObjects[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }
}
