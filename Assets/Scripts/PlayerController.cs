using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D characterRigidbody;
    public static Animator characterAnimator;

    private float horizontalInput;
    [SerializeField] private float characterSpeed = 4.5f;
    [SerializeField] private float jumpForce = 10f;

    public int _maxHealth {get; private set;} = 5;
    public int _currentHealth {get; private set;}

    private bool isAttacking;

    [SerializeField] private Transform attackHitBox;
    [SerializeField] private float attackRadius = 1;

    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //characterRigidbody.AddForce(Vector2.up * jumpForce);
        _currentHealth = _maxHealth;

        GameManager.instance.SetHealthBar(_maxHealth);
    }

    void Update()
    {
        Movement();
        
        if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded && !isAttacking)
        {
            Jump();
        }

        if(Input.GetButtonDown("Attack") && GroundSensor.isGrounded && !isAttacking)
        {
            //Attack();
            StartAttack();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.Pause();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(isAttacking)
        {
            characterRigidbody.velocity = new Vector2(0, characterRigidbody.velocity.y);
        }
        else
        {
            characterRigidbody.velocity = new Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y);
        }*/

        characterRigidbody.velocity = new Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y);
    }

    void Movement()
    {

        if(isAttacking && horizontalInput == 0)
        {
            horizontalInput = 0;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        if(horizontalInput < 0)
        {
            if(!isAttacking)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            characterAnimator.SetBool("IsRunning", true);
        }
        else if(horizontalInput > 0)
        {
            if(!isAttacking)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            characterAnimator.SetBool("IsRunning", true);
        }
        else
        {
            characterAnimator.SetBool("IsRunning", false);
        }

        /*if(isAttacking)
        {
            return;
        }

        if(horizontalInput == 0)
        {
            characterAnimator.SetBool("IsRunning", false);
        }
        else if(horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            characterAnimator.SetBool("IsRunning", true);
        }
        else if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            characterAnimator.SetBool("IsRunning", true);
        }*/
    }

    void Jump()
    {
        characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        characterAnimator.SetBool("IsJumping", true);
    }

    /*void Attack()
    {
        StartCoroutine(AttackAnimation());
        characterAnimator.SetTrigger("Attack");         
    }

    IEnumerator AttackAnimation()
    {
        isAttacking = true;

        yield return new WaitForSeconds(0.1f);

        Collider2D[] collider = Physics2D.OverlapCircleAll(attackHitBox.position, attackRadius);
        foreach(Collider2D enemy in collider)
        {
            if(enemy.gameObject.CompareTag("Mimico"))
            {
                //Destroy(enemy.gameObject);
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce(transform.right + transform.up * 2, ForceMode2D.Impulse);
            }
        }

        yield return new WaitForSeconds(0.4f);

        isAttacking = false;
    }*/

    void StartAttack()
    {
        isAttacking = true;
        characterAnimator.SetTrigger("Attack");
    }

    void Attack()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(attackHitBox.position, attackRadius);
        foreach(Collider2D enemy in collider)
        {
            if(enemy.gameObject.CompareTag("Mimico"))
            {
                //Destroy(enemy.gameObject);
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce(transform.right + transform.up * 2, ForceMode2D.Impulse);
            }
        }
    }

    void EndAttack()
    {
        isAttacking = false;
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        GameManager.instance.UpdateHealthBar(_currentHealth);
        
        if(_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            characterAnimator.SetTrigger("IsHurt");
        }
    }

    public void AddHealth(int health)
    {
        _currentHealth += health;

        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        GameManager.instance.UpdateHealthBar(_currentHealth);
    }

    void Die()
    {
        characterAnimator.SetTrigger("IsDead");
        Destroy(gameObject, 0.6f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            TakeDamage(1);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackHitBox.position, attackRadius);
    }
}
