using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNoCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 1.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnDelay)
        {
            timer = 0f;

            float randomX = Random.Range(-5f, 5f);
            Vector3 spawnPos = new Vector3(randomX, 0f, 8f);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
