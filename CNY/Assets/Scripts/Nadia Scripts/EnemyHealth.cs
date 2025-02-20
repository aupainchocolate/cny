using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    public void TakeDamage (int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
