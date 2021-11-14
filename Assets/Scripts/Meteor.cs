using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed;
    public float decayTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        decayTime -= Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (decayTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Destroyed()
    {
        Destroy(gameObject);
    }
}
