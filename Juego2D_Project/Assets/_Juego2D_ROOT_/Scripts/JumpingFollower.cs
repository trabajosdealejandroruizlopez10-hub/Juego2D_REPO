using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class JumpingFollower : MonoBehaviour
{
    [Header("Target Player")]
    public Transform player; // Arrastra tu Player aquí desde el Inspector

    [Header("Movement Settings")]
    public float moveSpeed = 2f;      // Velocidad horizontal
    public float jumpForce = 5f;      // Fuerza vertical del salto
    public float jumpCooldown = 0.5f; // Tiempo entre saltos

    [Header("Ground Check")]
    public Transform groundCheck;       // Empty en la base de la piedra
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;       // Layer del suelo

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

        // Calcula dirección horizontal hacia el Player
        float dirX = player.position.x - transform.position.x;

        // Voltea sprite según dirección
        if (dirX != 0)
            transform.localScale = new Vector3(Mathf.Sign(dirX), 1, 1);

        // Saltito solo si está en el suelo y el cooldown pasó
        if (jumpTimer >= jumpCooldown && IsGrounded())
        {
            jumpTimer = 0f;
            rb.linearVelocity = new Vector2(Mathf.Sign(dirX) * moveSpeed, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
