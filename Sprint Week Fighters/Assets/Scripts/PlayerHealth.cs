using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public bool canBeHit = true;

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
        Debug.Log(canBeHit);
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
        if (canBeHit == false)
        {
            return;
        }

        int amount = 5;

        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        canBeHit = false;
        StartCoroutine(HitTimer());
        if (currentHealth <= 0 && !deathCheck)
        {
            Death();
        }
    }

    public IEnumerator HitTimer(float time = 1)
    {
        yield return new WaitForSeconds(time);
        canBeHit = true;
    }

    void Death()
    {
        deathCheck = true;
    }
}
