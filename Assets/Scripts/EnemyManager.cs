using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform pointA;
    public Transform pointB;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPos = Vector3.Lerp(pointA.position, pointB.position, Random.Range(0f, 1f));
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
