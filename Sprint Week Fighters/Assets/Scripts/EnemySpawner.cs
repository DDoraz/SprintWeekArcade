using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int totalEnemyLeft = 10;
    public static int enemysKilled = 0;
    public static int enemiesOnScreen = 0;
    public static int enemiesSpawned;
    public bool spawning = true;
    public GameObject enemykillcounter;
    public GameObject enemy;
    public GameObject spawnLocation;
    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    public static float timeTillNextSpawn = 1f;
    public GameObject moveHere;

    public float spawnTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Point");
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        //print(currentPoint.name);

        //Debug.Log(spawning);
        //Debug.Log(totalEnemyLeft);
        Debug.Log(enemysKilled);
        


       
        //spawns enemy after spawn time
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0.0f && spawning == true)
        {
            SpawnEnemy();
        }

       

        //brings go signal
        if (totalEnemyLeft <= 0)
        {
            moveHere.SetActive(true);
        } else
        {
            moveHere.SetActive(false);
        }

    }

    public void SpawnEnemy()
    {
        if (totalEnemyLeft >= 1)
        {
            Instantiate(enemy, currentPoint.transform.position, Quaternion.identity);
            enemiesOnScreen++;
            enemiesSpawned++;
            spawnTime = timeTillNextSpawn;
        }
    }

    
    
}
