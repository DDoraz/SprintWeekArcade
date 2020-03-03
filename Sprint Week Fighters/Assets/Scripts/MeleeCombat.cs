﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int weakAttackDamage = 20;
    public int strongAttackDamage = 40;
    public float weakAttackRate = 2f;
    public float strongAttackRate = 1f;
    public float nextAttackTime = 0f;
    public GameObject fist;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / weakAttackRate;
                fist.SetActive(true);
            }
            else
            {
                fist.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                StrongAttack();
                nextAttackTime = Time.time + 1f / strongAttackRate;
                fist.SetActive(true);
            }
            else
            {
                fist.SetActive(false);
            }


        }


        
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<Enemies>().TakeDamage(weakAttackDamage);
        }

    }

    public void StrongAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<Enemies>().TakeDamage(strongAttackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}