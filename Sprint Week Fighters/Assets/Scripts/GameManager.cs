using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner.totalEnemyLeft = 10;
        EnemySpawner.enemysKilled = 0;
        EnemySpawner.enemiesOnScreen = 0;
        EnemySpawner.enemiesSpawned = 0;
           
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
