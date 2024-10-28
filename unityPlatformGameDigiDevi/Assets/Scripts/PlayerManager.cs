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
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        getInput();
        jump();
    }
    private void FixedUpdate()
    {
        move();
    }
    void move() 
    {
        if (Mathf.Abs(xInput) > 0) 
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }
    void jump() 
    {
        if (Input.GetKey(KeyCode.Space)) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void getInput()
    {
        xInput = Input.GetAxis("Horizontal"); // controlla il movimento sull'asse orizzontale della x
        yInput = Input.GetAxis("Vertical"); // controlla il movimento sull'asse orizzontale della Y
    }
}
