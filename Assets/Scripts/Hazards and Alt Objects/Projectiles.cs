using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectiles : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 velocity2 = new Vector2(0, 20);
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lifeTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = velocity2;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            collision.gameObject.GetComponent<Asteroid>().DamageMe(true);
        }
    }
}
