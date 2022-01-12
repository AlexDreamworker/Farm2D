using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthImage;

    public float enemyCurrentHealth = 100f, enemyMaxHealth = 100f;

    [HideInInspector] public bool isEnemyDeactivated;
    
    Coroutine enemyStoped;
    CircleCollider2D collider;
    FollowPath followPath;
 

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        followPath = GetComponent<FollowPath>();
    }

    private void Update()
    {
        healthImage.fillAmount = enemyCurrentHealth / enemyMaxHealth;

        if (isEnemyDeactivated)
        {
            enemyStoped = StartCoroutine(EnemyStoped(5f));
        }

        if(enemyCurrentHealth <= 0f)
        {
            EnemyDie();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.GC.isLose = true;
        }
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth = enemyCurrentHealth - damage;
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }

    IEnumerator EnemyStoped(float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            collider.enabled = false;
            followPath.enabled = false;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                yield return null;
            }
        }

        collider.enabled = true;
        followPath.enabled = true;
        isEnemyDeactivated = false;
    }
}
