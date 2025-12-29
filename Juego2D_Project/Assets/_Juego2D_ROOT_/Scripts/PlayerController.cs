using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jump Configuration")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    Rigidbody2D PlayerRB;
    Animator anim;
    PlayerInput input;
    Vector2 moveImput;


    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {

    }

    private void Update()
    {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
          
        if (anim != null)
        {
            anim.SetBool("isJumping", !isGrounded);
            anim.SetFloat("yVelocity", PlayerRB.linearVelocity.y);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        PlayerRB.linearVelocity = new Vector2(moveImput.x * speed, PlayerRB.linearVelocity.y);
        if (anim != null)
        {
            anim.SetBool("isRunning", moveImput.x != 0);

            if (moveImput.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveImput.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    public void OnMove(InputValue value)
    {
        moveImput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x,jumpForce);
        }
    }

}
