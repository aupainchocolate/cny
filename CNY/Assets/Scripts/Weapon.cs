using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;

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
        else
        {
            Debug.LogError("PlayerMovement script not found in the scene!");
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
        if (firePoint == null || shotPrefab == null)
        {
            Debug.LogError("FirePoint or ShotPrefab is not assigned!");
            return;
        }

        // Instansiera skottet
        GameObject shot = Instantiate(shotPrefab, firePoint.position, firePoint.rotation);

        // S�tt riktningen p� skottet
        Shot shotScript = shot.GetComponent<Shot>();
        if (shotScript != null)
        {
            shotScript.SetDirection(isFacingRight ? Vector2.right : Vector2.left);
        }
        else
        {
            Debug.LogError("Shot prefab does not have a Shot script attached!");
        }
    }
}
