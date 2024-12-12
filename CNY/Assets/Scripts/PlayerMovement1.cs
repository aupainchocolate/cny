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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    
    }
}
