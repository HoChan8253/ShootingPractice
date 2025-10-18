using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Settings")]
    [SerializeField] private float spawnDelay = 1.5f;
    [SerializeField] private int limit = 0;

    [Header("Coordinate")]
    [SerializeField] private float xMin = -5f;
    [SerializeField] private float xMax = 5f;
    [SerializeField] private float yPos = 0.5f;
    [SerializeField] private float zPos = 11f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        int spawned = 0;

        while (true)
        {
            if (limit > 0 && spawned >= limit)
            {
                yield break;
            }
            
            float randomX = Random.Range(xMin, xMax);
            Vector3 spawnPos = new Vector3(randomX, 0f, zPos);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);

            spawned++;
        }
    }
}
