using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public string moveHorizontal;
    public string moveVertical;

    public bool canBeHit = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(moveHorizontal), Input.GetAxisRaw(moveVertical));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
           // animator.SetBool("isWalking", true);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
           // animator.SetBool("isWalking", true);
        } 

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
        }else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.G))
        {
            animator.SetBool("walkingP2", true);
        }
        else
        {
            animator.SetBool("walkingP2", false);
        }

        //test ui health bar
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    public IEnumerator HitTimer(float time = 1)
    {
        yield return new WaitForSeconds(time);
        canBeHit = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

   public void TakeDamage(int damage)
    {
        if (canBeHit == false)
        {
            return;
        }
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        canBeHit = false;
        StartCoroutine(HitTimer());
    }
}
