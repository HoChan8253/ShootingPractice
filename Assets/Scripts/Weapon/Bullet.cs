using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField][Range(1f, 30f)] private float bulletSpeed;
    [SerializeField] private float lifeTime = 5f;
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
    
        if(other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
