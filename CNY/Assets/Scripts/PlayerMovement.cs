using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumoForce = 10f;
    public CharacterController controll;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundlayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;    
    public Animator animator;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;

        //player move along with rigidbody 
        rb.MovePosition(rb.transform.position + tempVect);



        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
