using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;   
    [SerializeField] public float jumpForce = 5f; 

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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float h = Input.GetAxisRaw("Horizontal") * moveSpeed;

        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
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

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
