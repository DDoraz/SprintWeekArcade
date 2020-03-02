using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float f_speed;

    public float f_health;

    public float f_damage;

    //The target transform for the player
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the transform of the gameobject tagged player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x <= 3f || target.position.x >= -3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, f_speed * Time.deltaTime);

        }
    }
}
