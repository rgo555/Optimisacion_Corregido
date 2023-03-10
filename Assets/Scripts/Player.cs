using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public string BulletTag;

    public Transform canon1;
    public Transform canon2;

    void Start()
    {

    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        transform.position += move * speed * Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0;
            if (direction.magnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Quaternion rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
            ObjectPooler.Instance.SpawnFromPool(BulletTag, canon1.TransformPoint(Vector3.zero), rotation);
            ObjectPooler.Instance.SpawnFromPool(BulletTag, canon2.TransformPoint(Vector3.zero), rotation);
        }
    }
}
