using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private int hp = 3;

    [Header("Movement")]
    [SerializeField] private Transform player;
    [SerializeField] private float baseSpeed = 2f;
    
    [Header("Tags")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private string wallTag = "Wall";
 
    private void Update()
    {
        transform.Translate(Vector3.back * baseSpeed * Time.deltaTime);
    }

    public void Hit()
    {
        hp--;
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var bullet = other.GetComponent<Bullet>();
        if(bullet != null)
        {
            Hit();
            Destroy(other.gameObject);
        }
        
        if(other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
