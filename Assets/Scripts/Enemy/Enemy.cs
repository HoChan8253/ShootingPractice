using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private int hp = 5;

    [Header("Movement")]
    [SerializeField] private Transform player;
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private float rotateSpeed = 100f;
    
    [Header("Tags")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private string wallTag = "Wall";
 
    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.back * baseSpeed * Time.deltaTime, Space.World);
    }

    public void Hit()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {                
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
