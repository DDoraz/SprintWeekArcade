using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    bool deathCheck;
    bool damaged;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {

        }

        else
        {

        }

        damaged = false;
    }

    public void TakeDamage()
    {
        int amount = 5;

        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !deathCheck)
        {
            Death();
        }
    }

    void Death()
    {
        deathCheck = true;
    }
}
