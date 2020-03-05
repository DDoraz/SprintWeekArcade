using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private SpawnManager _spawnManager;

    public AudioClip enemyHit;
    public AudioClip enemyDeath;
    private AudioSource source;



    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        source.PlayOneShot(enemyHit, 1);
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        source.PlayOneShot(enemyDeath, 1);
        Destroy(gameObject);
        Debug.Log("oh ma god she fukin dead");
        EnemySpawner.enemiesOnScreen--;
        EnemySpawner.totalEnemyLeft--;
        EnemySpawner.enemysKilled++;
        _spawnManager.EnemyDefeated();


        ;
    }
}
