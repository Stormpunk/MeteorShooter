using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().HealPlayer(1);
            Debug.Log("Healing player");
            Destroy(this.gameObject);
        }
    }
}
