using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


}
