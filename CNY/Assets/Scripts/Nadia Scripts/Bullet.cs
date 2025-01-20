using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction = Vector2.right; // Standardriktning

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component missing on Shot!");
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
