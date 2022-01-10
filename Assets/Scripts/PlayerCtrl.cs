using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer sprite;

    public float playerSpeed;
    public Joystick joysctick;

    private Vector2 moveVelocity;

    public GameObject bombPrefab;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 moveInput = new Vector2(joysctick.Horizontal, joysctick.Vertical);
        moveVelocity = moveInput * playerSpeed;

        if (joysctick.Horizontal > 0) sprite.sprite = sprites[0];
        if (joysctick.Horizontal < 0) sprite.sprite = sprites[1];
        if (joysctick.Vertical > 0 && joysctick.Horizontal > 0) sprite.sprite = sprites[3];
        if (joysctick.Vertical < 0 && joysctick.Horizontal < 0) sprite.sprite = sprites[2];
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void BombSpawner()
    {
        Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
