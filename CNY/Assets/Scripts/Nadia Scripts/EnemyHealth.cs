using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
