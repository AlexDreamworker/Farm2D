using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public Joystick joystick;
    public GameObject bombPrefab;

    public float moveSpeed;

    private float x;
    private float y;

    private Vector2 bombPoint;
    private Vector2 input;
    private bool isMoving, isBombReloading;

    Animator anim;
    Rigidbody2D rb; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        Animate();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("isMoving", isMoving);
    }

    public void BombSpawner()
    {
        Instantiate(bombPrefab, bombPoint, Quaternion.identity);     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            bombPoint = collision.transform.position;
        }
    }
}
