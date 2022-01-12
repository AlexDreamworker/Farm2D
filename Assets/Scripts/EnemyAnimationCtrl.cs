using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationCtrl : MonoBehaviour
{
    public enum Directions
    {
        X,
        Y
    }

    public Directions direction;
    public Sprite sprite1, sprite2;

    SpriteRenderer spriteRenderer;

    Vector2 startPosX;
    Vector2 startPosY;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosX = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        startPosY = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void Update()
    {
        if (direction == Directions.X)
        {
            if (gameObject.transform.position.x > startPosX.x)
            {
                spriteRenderer.sprite = sprite1;
                startPosX = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }

            if (gameObject.transform.position.x < startPosX.x)
            {
                spriteRenderer.sprite = sprite2;
                startPosX = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }
        }

        if (direction == Directions.Y)
        {
            if (gameObject.transform.position.y > startPosY.y)
            {
                spriteRenderer.sprite = sprite1;
                startPosY = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }

            if (gameObject.transform.position.y < startPosY.y)
            {
                spriteRenderer.sprite = sprite2;
                startPosY = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }
        }
    }
}
