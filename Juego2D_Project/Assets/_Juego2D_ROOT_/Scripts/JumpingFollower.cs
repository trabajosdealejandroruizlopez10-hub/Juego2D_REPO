using UnityEngine;

public class FireRockMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float forwardSpeed = 2f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(forwardSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce / 2f);
    }
}
