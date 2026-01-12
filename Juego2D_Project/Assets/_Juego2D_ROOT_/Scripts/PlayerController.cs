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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        AnimationLogic();
      
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        PlayerRB.linearVelocity = new Vector2(moveImput.x * speed, PlayerRB.linearVelocity.y);
        if (moveImput.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveImput.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void AnimationLogic()
    {
        if (anim != null)
        {
            anim.SetBool("isRunning", moveImput.x != 0);
            anim.SetBool("isJumping", PlayerRB.linearVelocity.y > 0.1f && !isGrounded);
            anim.SetBool("isFalling", PlayerRB.linearVelocity.y < -0.1f && !isGrounded);
            anim.SetFloat("yVelocity", PlayerRB.linearVelocity.y);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveImput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.performed && isGrounded)
        {
            PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
