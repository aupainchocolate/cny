using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerController playerController;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsAttacking", true); // Play attacking animation
            playerController.KBCounter = playerController.KBTotalTime;
            if (collision.gameObject.transform.position.x <= transform.position.x)
            {
                playerController.KnockFromRight = true;
            }
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                playerController.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);

            // Reset attacking animation after a delay
            Invoke("ResetAttackAnimation", 0.5f); // Adjust delay as needed
        }
    }

    private void ResetAttackAnimation()
    {
        animator.SetBool("IsAttacking", false); // Stop attacking animation
    }
}