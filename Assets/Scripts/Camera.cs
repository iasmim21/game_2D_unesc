using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float verticalDeadZone = 1.5f;

    private float camHeight;
    private Collider2D targetCollider;

    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2f;
        targetCollider = target.GetComponent<Collider2D>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        float desiredX = target.position.x + offset.x;
        float desiredY = transform.position.y;

        float camTop = transform.position.y + camHeight / 2f;
        float camBottom = transform.position.y - verticalDeadZone;

        float targetTopY = target.position.y + offset.y;
        float targetBottomY = target.position.y;

        if (targetCollider != null)
        {
            targetBottomY = targetCollider.bounds.min.y;
        }

        if (targetTopY > camTop)
        {
            desiredY = targetTopY - camHeight / 2f;
        }
         else if (targetBottomY < (camBottom))
        {
            desiredY = targetBottomY + verticalDeadZone;
        }

        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            desiredY,
            offset.z
        );

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
