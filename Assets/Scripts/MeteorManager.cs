using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public GameObject meteor;
    //gameobject
    public Transform pointA;
    public Transform pointB;
    //the two extremes of the spawn point, the object will spawn randomly in between this range.
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 1, 1);
        //calls the spawn function ever 1 second
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnMeteor()
    {
        Debug.Log("Spawning a Meteor because I can't SEE IT");
        //fixed it, I think the gameobject was too high above the camera? facepalm
        Vector3 spawnPos = Vector3.Lerp(pointA.position, pointB.position, Random.Range(0f, 1f));
        Instantiate(meteor, spawnPos, Quaternion.identity);
    }
}
