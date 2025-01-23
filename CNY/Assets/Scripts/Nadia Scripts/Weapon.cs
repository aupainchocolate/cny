using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool isFacingRight = true; // Standardriktning är åt höger

    private void Start()
    {
        // Hämta PlayerMovement-komponenten
        PlayerMovement player = Object.FindFirstObjectByType<PlayerMovement>();
        if (player != null)
        {
            // Lyssna på spelarens flip-händelse
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

        // Sätt riktningen på skottet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(isFacingRight ? Vector2.right : Vector2.left);
        }
    }
}
