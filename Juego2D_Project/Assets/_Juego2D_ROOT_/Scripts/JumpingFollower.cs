using UnityEngine;

public class JumpingFollower : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Movement & Jump")]
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform groundCheck; // Empty debajo de la piedra
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        // Revisar si está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            JumpTowardsPlayer();
        }
    }

    private void JumpTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        rb.linearVelocity = new Vector2(direction.x * moveSpeed, 0f);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
