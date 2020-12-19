using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;//default is 8
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float jumpForce = 30f;//default is 30
    [SerializeField] private int maxJumps = 2;//default is 2
    private int jumps = 0;//the amount of jumps player has done
    [SerializeField] private bool isGrounded = true;//Checks if player is touching the ground - default true

    SpriteRenderer sr;//the player's sprite renderer
    Rigidbody2D rb;//the player's rigidbody


    // Start is called before the first frame update
    void Start()
    {
        /*Get Components - SpriteRenderer & Rigidbody2D*/
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        /*When Colliding With The Ground*/
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            jumps = 0;
           
        }
    }

    private void Move()
    {
        /*Jump*/
        if ((Input.GetKeyDown(KeyCode.Z)) && jumps < maxJumps)
        {
            isGrounded = false;
            jumps++;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        /*Moves Left and Right*/
        /*gound true*/
        if  (isGrounded == true && (Input.GetKey(KeyCode.D)))//right
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        if (isGrounded == true && (Input.GetKey(KeyCode.Q)))//left
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }
        /*ground fals*/
        if (isGrounded == false && (Input.GetKey(KeyCode.D)))//right
        {
            rb.velocity = new Vector2(jumpSpeed, rb.velocity.y);

        }
        if (isGrounded == false && (Input.GetKey(KeyCode.Q)))//left
        {
            rb.velocity = new Vector2(-jumpSpeed, rb.velocity.y);

        }

    }
}
