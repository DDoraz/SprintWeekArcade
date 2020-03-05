using System.Collections;
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
    public KeyCode lightAttack;
    public KeyCode heavyAttack;
    public AudioClip lightPunch;
    public AudioClip hardPunch;
    private AudioSource source;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(lightAttack))
            {
                source.PlayOneShot(lightPunch, 1);
                animator.SetBool("isWalking", false);
                Attack();
                nextAttackTime = Time.time + 1f / weakAttackRate;
            }
            if (Input.GetKeyDown(heavyAttack))
            {
                source.PlayOneShot(hardPunch, 1);
                animator.SetBool("isWalking", false);
                StrongAttack();
                nextAttackTime = Time.time + 1f / strongAttackRate;        
            }
        }
     
    }

    public void Attack()
    {
        animator.SetTrigger("LightAttack");
        animator.SetTrigger("lightPunch");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<Enemies>().TakeDamage(weakAttackDamage);
            enemy.GetComponent<EnemyAI>().currentEnemyState = EnemyAI.EnemyState.Hit;
        }

    }

    public void StrongAttack()
    {
        
        animator.SetTrigger("HeavyAttack");
        animator.SetTrigger("heavyPunch");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<Enemies>().TakeDamage(strongAttackDamage);
            enemy.GetComponent<EnemyAI>().currentEnemyState = EnemyAI.EnemyState.Hit;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
