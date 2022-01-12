using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float countdown;
    Enemy enemy;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().isEnemyDeactivated = true;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(50f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.GC.isLose = true;
        }
    }
}
