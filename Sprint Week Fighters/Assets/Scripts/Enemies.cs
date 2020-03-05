using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private SpawnManager _spawnManager;



    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("oh ma god she fukin dead");
        EnemySpawner.enemiesOnScreen--;
        EnemySpawner.totalEnemyLeft--;
        EnemySpawner.enemysKilled++;
        _spawnManager.EnemyDefeated();


        ;
    }
}
