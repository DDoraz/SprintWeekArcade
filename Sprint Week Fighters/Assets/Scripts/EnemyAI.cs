using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 1.5f;
    private Transform target;
    public bool stopedMoving = false;
    public float timeTillIdle = 2.5f;
    public float timeTillMove = 2.5f;
    void Start()
     {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
     void Update()
     {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

        timeTillIdle -= Time.deltaTime;

        if (timeTillIdle <= 0.0f)
        {
            enemySpeed = 0f;
            stopedMoving = true;
          
        }

        if(stopedMoving == true)
        {
            timeTillMove -= Time.deltaTime;
        }

        if(stopedMoving == false)
        {
            timeTillMove = 2.5f;
        }


        if (timeTillMove <= 0f)
        {
            stopedMoving = false;
            enemySpeed = 1.5f;
            timeTillIdle = 2.5f;
        }
    }
}

    

