using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    public GameObject bullet;
    public int missileAmmo;
    public int maxMissileAmmo;
    public Collider explosionCol;
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxMissileAmmo = 3;
        maxHealth = 5;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        #region Basic Movement
        Vector3 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Vertical");
        movement *= Time.deltaTime * speed;
        transform.Translate(movement);
        #endregion
        #region Combat Functions
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Firing Default Projectile");
            Instantiate(bullet, transform.position, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.X) && missileAmmo > 0)
        {
            Explosion();
            missileAmmo -= 1;
        }
        if(missileAmmo >= maxMissileAmmo)
        {
            missileAmmo = maxMissileAmmo;
        }
        if(Input.GetKeyDown(KeyCode.C) && missileAmmo > 0)
        {
            ClearMeteor();
        }
        #endregion
    }
    void Explosion()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }
    void ClearMeteor()
    {
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject meteor in meteors)
        {
            GameObject.Destroy(meteor);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
     if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
        }   
    }
}
