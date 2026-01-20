using UnityEngine;

public class JumpingFollower : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Movement")]
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpCooldown = 1.5f;

    private Rigidbody2D rb;
    private float jumpTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        jumpTimer += Time.deltaTime;

        if (jumpTimer >= jumpCooldown)
        {
            JumpTowardsPlayer();
            jumpTimer = 0f;
        }
    }

    private void JumpTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction.x * moveSpeed, jumpForce), ForceMode2D.Impulse);
    }
}
