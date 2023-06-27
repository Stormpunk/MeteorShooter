using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float fallSpeed;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float lifeTime;

    [SerializeField] private GameObject medKit;

    private float spawnChance = 3f / 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DamageMe(true) ;
        }
            Fall();
    }

    private void Fall()
    {
        rb.velocity = Vector2.down * fallSpeed;
    }

    public void DamageMe(bool damaged)
    {
        
        if (Random.Range(0f, 1f) <= spawnChance && damaged == true )
        {
            Instantiate(medKit, this.transform.position, Quaternion.identity);
        }
        //only has a chance to spawn the medkit if the damage source (bool) is true (a projectile or other hostile action) it will not spawn if it hits the player.
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            DamageMe(false);
            collision.gameObject.GetComponent<Health>().DamagePlayer(1);
            } 
    }
}
