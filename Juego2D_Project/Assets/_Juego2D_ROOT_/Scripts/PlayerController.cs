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
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        PlayerRB.linearVelocity = new Vector2(moveImput.x * speed, PlayerRB.linearVelocity.y);
    }


    public void OrMove(InputAction.CallbackContext context)
    {
        moveImput = context.ReadValue<Vector2>();
    }


}
