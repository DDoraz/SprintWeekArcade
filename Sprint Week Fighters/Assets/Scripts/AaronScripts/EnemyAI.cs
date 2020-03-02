using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public float f_speed;

    public float f_health;

    public float f_damage;

    //The target transform for the player
    private Transform t_Target;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the transform of the gameobject tagged player
        t_Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the player comes in range of the enemy, the enemy will stop
        if(t_Target.position.x <= t_Target.position.x + 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, t_Target.position, f_speed * Time.deltaTime);
        }
    }

    void PunchAttack()
    {
        Debug.Log("A punch was thrown");
    }
}
