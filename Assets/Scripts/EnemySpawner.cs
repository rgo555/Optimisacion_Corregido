using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform Player;
    public float radiusAroundPlayer;
    float elapsedTime;
    public float interval;
    public string EnemyTag;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= interval)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radiusAroundPlayer;
            Vector3 spawnPosition = Player.position + new Vector3(randomCircle.x, 0f, randomCircle.y);
            ObjectPooler.Instance.SpawnFromPool(EnemyTag, spawnPosition, Quaternion.identity);
            elapsedTime = 0f;
        }
    }
}
