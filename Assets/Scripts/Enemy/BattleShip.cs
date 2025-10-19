using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShip : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [Header("Tags")]
    [SerializeField] private string PlayerTag = "Player";
    [SerializeField] private string WallTag = "Wall";

    [Header("Info")]
    [SerializeField] private int hp = 10;

    [Header("Settings")]
    [SerializeField] private float spawnDelay;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float fireInterval = 1.5f;
    [SerializeField] private float bulletSpeed = 2f;
    [SerializeField] private float bulletLifeTime = 3f;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }
    
    private IEnumerator FireRoutine()
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.back * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
