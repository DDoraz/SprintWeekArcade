using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 1.5f;
    private Transform target;
    public bool stopedMoving = false;
    public float idleTime = 2.5f;
    public float moveTime = 2.5f;
    public float minAttackDistance = 1.5f;
    public bool ableToAttack = false; 


    public enum EnemyState {Idle, Attack, Moving, Hit, Dead }
    public EnemyState currentEnemyState;
 
    public void Start()
    {
        currentEnemyState = EnemyState.Moving;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        switch (currentEnemyState)
        {
            case EnemyState.Idle:
                idleTime -= Time.deltaTime;
                if (idleTime <= 0.0f)
                {
                    currentEnemyState = EnemyState.Moving;
                    idleTime = 2.5f;
                }
                if (distance < minAttackDistance)
                {
                    currentEnemyState = EnemyState.Attack;
                    ableToAttack = true;
                }

                Debug.Log("playerIdle");
                break;
            case EnemyState.Attack:
                if(ableToAttack == true)
                {
                    //add combat here to damage player
                    ableToAttack = false;
                    currentEnemyState = EnemyState.Idle;
                }
                Debug.Log("player Attacking");
                break;
            case EnemyState.Moving:
                Debug.Log("player moving");
                moveTime -= Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                if (moveTime <= 0.0f)
                {
                    currentEnemyState = EnemyState.Idle;
                    moveTime = 2.5f;
                }
                if (distance < minAttackDistance)
                {
                    currentEnemyState = EnemyState.Attack;
                    ableToAttack = true;
                }
                break;
            case EnemyState.Hit:
                Debug.Log("player hit");
                break;
            case EnemyState.Dead:
                Debug.Log("player dead");
                break;
            
        }
    }








































    /*public float enemySpeed = 1.5f;
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
    }*/
}

    

