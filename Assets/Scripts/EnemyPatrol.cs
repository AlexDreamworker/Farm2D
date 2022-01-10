using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float enemySpeed, startWaitTime;
    private float waitTime;

    public Transform[] movePoints;
    private int randomSpot;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movePoints.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[randomSpot].position, enemySpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.RandomRange(0, movePoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
