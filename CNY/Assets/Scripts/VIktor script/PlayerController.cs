using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
   
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 15f;
    private float currentSpeed;

    [Header("Jump Settings")]
    public float jumpForce = 10f;
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private bool isJumping;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = horizontalInput * moveSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed,
            (horizontalInput == 0 ? deceleration : acceleration) * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        // Handle jumping
        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}