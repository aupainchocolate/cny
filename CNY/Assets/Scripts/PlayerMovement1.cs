using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;   
    [SerializeField] public float jumpForce = 10f; 

    public Transform groundCheck;                  
    public float groundCheckRadius = 0.2f;       
    public LayerMask groundLayer;               

    private Rigidbody2D rb;                     
    private bool isGrounded = false;              
    public Animator animator;                      

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();          
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movement input
        float h = Input.GetAxis("Horizontal");

        // Move player horizontally
        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Set animations (if applicable)
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(h));
            animator.SetBool("IsGrounded", isGrounded);
        }
    }
}
