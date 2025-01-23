using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool isFacingRight = true; // Standardriktning �r �t h�ger

    private void Start()
    {
        // H�mta PlayerMovement-komponenten
        PlayerMovement player = Object.FindFirstObjectByType<PlayerMovement>();
        if (player != null)
        {
            // Lyssna p� spelarens flip-h�ndelse
            player.OnPlayerFlip += UpdateDirection;
        }
    }

    private void UpdateDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("FirePoint or ShotPrefab is not assigned!");
            return;
        }

        // Instansiera skottet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // S�tt riktningen p� skottet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(isFacingRight ? Vector2.right : Vector2.left);
        }
    }
}
