using UnityEngine;

public class Patrol : MonoBehaviour
{
    public BoxCollider2D triggerVertical, triggerHorizontal;

    public float enemySpeed;

    Vector3 pointPos;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.MovePosition(pointPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            pointPos = collision.transform.position;
        }
    }
}
