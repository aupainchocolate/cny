using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 35f;
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

    [Header("KnockBack")]
    public float KBForce; // Knockback force
    public float KBCounter; // Knockback duration counter
    public float KBTotalTime; // Total knockback duration
    public bool KnockFromRight; // Direction of knockback

    [Header("PLayer FLipping")]
    public bool isFacingRight = true;

    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only allow input if not in knockback
        if (KBCounter <= 0)
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

            float moveInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);

            if ((moveInput > 0 && !isFacingRight) || (moveInput < 0 && isFacingRight))
            {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            // Normal movement
            float targetSpeed = horizontalInput * moveSpeed;
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed,
                (horizontalInput == 0 ? deceleration : acceleration) * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Reduce knockback counter
            KBCounter -= Time.deltaTime;

            // Maintain horizontal knockback velocity
            float knockbackDirection = KnockFromRight ? -1 : 1;
            rb.linearVelocity = new Vector2(knockbackDirection * KBForce, rb.linearVelocity.y);
        }

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

    void FLip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}