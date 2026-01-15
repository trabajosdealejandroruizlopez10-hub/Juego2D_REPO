using UnityEngine;

public class JumpingFollower : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpCooldown = 0.5f;
    public Transform player;
    public void SetPlayer(Transform p)
    {
        player = p;
    }

    public void Player(Transform p)
    {
        player = p;
    }


    private Rigidbody2D rb;
    private float jumpTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        jumpTimer += Time.deltaTime;

        float dirX = player.position.x - transform.position.x;

        if (dirX != 0)
            transform.localScale = new Vector3(Mathf.Sign(dirX), 1, 1);

        if (jumpTimer >= jumpCooldown)
        {
            jumpTimer = 0f;
            rb.linearVelocity = new Vector2(Mathf.Sign(dirX) * moveSpeed, jumpForce);
        }
    }
}

