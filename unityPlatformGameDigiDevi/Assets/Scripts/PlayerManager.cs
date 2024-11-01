using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    public float xInput;
    public float yInput;
    public bool grounded;
    public LayerMask GroundMask;
    public BoxCollider2D groundCheck;
    public SpriteRenderer character;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        getInput();
        move();
        
    }
    void FixedUpdate()
    {
        checkGround();
    }
    void getInput()
    {
        xInput = Input.GetAxis("Horizontal"); 
        yInput = Input.GetAxis("Vertical"); 
    }
    void move()
    {
        if(Mathf.Abs(xInput) > 0)
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
            if(xInput > 0)
            {
                character.flipX = false;
            }
            if(xInput < 0)
            {
                character.flipX = true;
            }
        }
        if(Input.GetKey("space") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void checkGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, GroundMask).Length > 0;
    }
    
}
