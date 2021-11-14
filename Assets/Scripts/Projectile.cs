using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(transform.position.z > 6.5f || transform.position.z < -7f)
        {
            Destroy(gameObject);
        }
        player = GameObject.FindWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HitEnemy");
            collision.gameObject.GetComponent<Enemy>().Die();
            Destroy(gameObject);
            player.GetComponent<PlayerController>().missileAmmo++;
        }
        else if (collision.gameObject.tag == "Meteor")
        {
            collision.gameObject.GetComponent<Meteor>().Destroyed();
            Destroy(gameObject);
        }
    }
    
}
