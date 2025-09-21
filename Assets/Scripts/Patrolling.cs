using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private Rigidbody2D rb;
    private Transform currentPoint;
    private float pointRadius = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
    }
    void Update()
    {
        if (currentPoint == pointA.transform) rb.linearVelocity = new Vector2(speed, 0);
        else rb.linearVelocity = new Vector2(-speed, 0);

        if (Vector2.Distance(transform.position, currentPoint.position) < pointRadius)
        {
            Switch();
        }
    }
    private void Switch()
    {
        if (currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        else
        {
            currentPoint = pointA.transform;
        }
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointB.transform.position, pointRadius);
        Gizmos.DrawWireSphere(pointA.transform.position, pointRadius);
        Gizmos.DrawLine(pointB.transform.position, pointA.transform.position);

    }

}
