using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform Player;
    public float speed;

    void Awake()
    {
        Player = GameObject.Find("Player").transform;
    }

    private void Update()
    {

        Vector3 direction = Player.position - transform.position;
        direction.y = 0f; 
        
        transform.position += direction.normalized * speed * Time.deltaTime;
        
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
