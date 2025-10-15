using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField][Range(0.1f, 1f)] private float fireRate;

    private float _fireDelay = 0f;

    void Update()
    {
        if (_fireDelay > 0f)
        {
            _fireDelay -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && _fireDelay <= 0f)
        {
            Shoot();
            _fireDelay = fireRate;
            Debug.Log("스페이스바 눌림");
        }
    }

    private void Shoot()
    {
        if (_gameObject == null || spawnPoint == null) { return; }

        GameObject bullet = Instantiate(_gameObject, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("발사!");
    }
}
