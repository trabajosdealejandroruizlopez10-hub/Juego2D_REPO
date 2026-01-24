using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float jumpForce = 6f;
    public float detectionRange = 8f;
    public float attackRange = 1.5f;

    [Header("Attack")]
    public float attackCooldown = 1.2f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded;
    private bool canAttack = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            ChasePlayer(distance);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    void ChasePlayer(float distance)
    {
        
        float direction = player.position.x - transform.position.x;

      
        if (direction > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        if (distance > attackRange)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.linearVelocity.y);
            anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetFloat("Speed", 0);

            if (canAttack)
                Attack();
        }
    }

    void Attack()
    {
        canAttack = false;
        anim.SetTrigger("Attack");
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

  
    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
