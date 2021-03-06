﻿using System.Collections;
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
    public float stunTime = 1f;
    public Animator animator;

    public AudioClip enemyAttack;
    private AudioSource source;




    public enum EnemyState {Idle, Attack, Moving, Hit, Dead }
    public EnemyState currentEnemyState;
 
    public void Start()
    {
        source = GetComponent<AudioSource>();
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

                //Debug.Log("playerIdle");
                break;
            case EnemyState.Attack:
                if(ableToAttack == true)
                {
                    source.PlayOneShot(enemyAttack, 1);
                    animator.SetTrigger("EnemyPunch");
                    target.gameObject.GetComponent<CharacterController>().TakeDamage(10);
                    ableToAttack = false;
                    currentEnemyState = EnemyState.Idle;
                }
                //Debug.Log("player Attacking");
                break;
            case EnemyState.Moving:
                animator.SetBool("EnemyWalk", true);
                //Debug.Log("player moving");
                moveTime -= Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                if (moveTime <= 0.0f)
                {
                    currentEnemyState = EnemyState.Idle;
                    moveTime = 2.5f;
                    animator.SetBool("EnemyWalk", false);
                }
                if (distance < minAttackDistance)
                {
                    currentEnemyState = EnemyState.Attack;
                    ableToAttack = true;
                    animator.SetBool("EnemyWalk", false);
                }
                break;
            case EnemyState.Hit:
                //Debug.Log("player hit");
                animator.SetTrigger("damagedEnemy");
                stunTime -= Time.deltaTime;
                if (stunTime <= 0.0f)
                {
                    currentEnemyState = EnemyState.Moving;
                    stunTime = 1f;
                }
                break;
            case EnemyState.Dead:
                //Debug.Log("player dead");
                break;
            
        }
    }
}

    

