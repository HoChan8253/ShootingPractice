using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField][Range(1f, 30f)] private float bulletSpeed;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private string enemyTag = "Enemy";
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(enemyTag))
        {
            return;
        }

        Enemy enemy = other.GetComponent<Enemy>();
        if(other.CompareTag(enemyTag))
        {
            enemy.Hit();
        }
        Destroy(gameObject);
    }
}
