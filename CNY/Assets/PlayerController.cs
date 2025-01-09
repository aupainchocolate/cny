using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    [Header("Variabler")]
    public Vector3 CameraStartPos;

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

    [Header("Feedback/ScreenShake")]
    public Camera mainCamera;
    public float fallShakeIntensity = 3f;
    public float hitShakeIntensity = 0.5f;
    public float shakeDuration = 0.2f;

    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        CameraStartPos = mainCamera.transform.position;
        
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

        if (rb.linearVelocity.y < -10f && isGrounded)
        {
            StartCoroutine(ShakeCamera(fallShakeIntensity, shakeDuration));
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = horizontalInput * moveSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed,
            (horizontalInput == 0 ? deceleration : acceleration) * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    private IEnumerator ShakeCamera(float intensity, float duration)
    {
        Vector3 originalPosition = mainCamera.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float xShake = Random.Range(-intensity, intensity);
            float yShake = Random.Range(-intensity, intensity);

            mainCamera.transform.position = new Vector3(originalPosition.x + xShake, originalPosition.y + yShake, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
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

    public void TakeDamage()
    {
        StartCoroutine(ShakeCamera(hitShakeIntensity, shakeDuration));
        BackToNormalCameraPos();
    }

    public void BackToNormalCameraPos()
    {
        mainCamera.transform.position = CameraStartPos;
    }
}
