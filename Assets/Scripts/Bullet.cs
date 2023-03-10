using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    string bullet = "Bullet";
    string enemy = "Enemy";

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger enter");
        ObjectPooler.Instance.ReturnToPool(bullet, this.gameObject);
        if(other.CompareTag("Enemy"))
        {
            ObjectPooler.Instance.ReturnToPool(enemy, other.gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        ObjectPooler.Instance.ReturnToPool(bullet, this.gameObject);
    }
}
