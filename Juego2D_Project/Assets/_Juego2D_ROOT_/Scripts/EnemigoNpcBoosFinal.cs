using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float detectionRange = 8f;
    public float attackRange = 1.5f;

    [Header("Attack")]
    public float attackCooldown = 1.2f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;

    private bool canAttack = true;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > detectionRange)
        {
            Stop();
            return;
        }

        if (isAttacking) return;

        float direction = player.position.x - transform.position.x;

        // Flip
        transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);

        if (distance > attackRange)
        {
            // RUN
            rb.linearVelocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.linearVelocity.y);
            anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        }
        else if (canAttack)
        {
            // ATTACK
            rb.linearVelocity = Vector2.zero;
            anim.SetFloat("Speed", 0);
            StartAttack();
        }
    }

    void Stop()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        anim.SetFloat("Speed", 0);
    }

    void StartAttack()
    {
        isAttacking = true;
        canAttack = false;
        anim.SetTrigger("Attack");
        Invoke(nameof(EndAttack), attackCooldown);
    }

    void EndAttack()
    {
        isAttacking = false;
        canAttack = true;
    }
}



