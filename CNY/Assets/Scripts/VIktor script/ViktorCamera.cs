using UnityEngine;

public class ViktorCamera : MonoBehaviour
{
    [Header("Player Target")]
    public Transform player;

    [Header("Camera Settings")]
    public float smoothSpeed = 0.05f;
    public Vector3 offset;

    [Header("Bounds")]
    public BoxCollider2D boundsBox;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        if (boundsBox == null)
        {
            Debug.LogError("Bounds BoxCollider2D is not assigned to the CameraController!");
            return;
        }

        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;
    }

    void LateUpdate()
    {
        if (player == null || boundsBox == null) return;

        Vector3 desiredPosition = player.position + offset;

        float cameraHalfHeight = cam.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * cam.aspect;

        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void OnDrawGizmos()
    {
        if (boundsBox != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(boundsBox.bounds.center, boundsBox.bounds.size);
        }
    }
}