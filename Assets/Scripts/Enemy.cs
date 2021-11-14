using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float decayTime = 10f;
    public float dropChance;
    public GameObject healthPack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        dropChance = 1f / 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * 5f * Time.deltaTime;
        decayTime -= Time.deltaTime;
        if (decayTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Die()
    {
        if(Random.Range(0f, 1f)<= dropChance)
        {
            Object.Instantiate(healthPack, transform.parent) ;
        }
        Destroy(gameObject);
    }
}
