using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameSysManager : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private float timer;
    private bool asteroidisSpawned;
    public GameObject asteroid;
    public int asteroidsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        asteroidisSpawned = false;
        asteroidsToSpawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            StartCoroutine(NewAsteroid());
            timer = 0;
        }
    }

   public IEnumerator NewAsteroid()
   {
       if (asteroidisSpawned == false && asteroidsToSpawn > 0)
       {
           //creates a random position between -8.5 and 8.5 horizontally and spawns it 8 above the center of the screen
           startPos = new Vector2(Random.Range(-8.5f, 8.5f), 8 );

                Instantiate(asteroid, startPos, Quaternion.identity);
                asteroidsToSpawn -= 1;
           yield return new WaitForSeconds(0.5f);
           asteroidisSpawned = true;
       }

       yield return new WaitForSeconds(0.5f);
       timer = 1f;
       asteroidisSpawned = false;
        asteroidsToSpawn = 1;


   }
}
