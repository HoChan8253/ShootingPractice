using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("PlayableArea")]
    public float xLimit = 5f;
    public float zLimit = 8f;   
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        transform.position += dir * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float clampedZ = Mathf.Clamp(transform.position.z, -zLimit, zLimit);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
