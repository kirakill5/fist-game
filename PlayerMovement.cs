using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;//default is 8
    [SerializeField] private float jumpForce = 30f;//default is 30
    [SerializeField] private int maxJumps = 2;//default is 2
    private int jumps = 0;//the amount of jumps player has done
    [SerializeField] private bool isGrounded = true;//Checks if player is touching the ground - default true
    [SerializeField] private bool facingRight = true;//Checks if player is looking right - default true

    SpriteRenderer sr;//the player's sprite renderer
    Rigidbody2D rb;//the player's rigidbody


    // Start is called before the first frame update
    void Start()
    {
        /*Get Components - SpriteRenderer & Rigidbody2D*/
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetBool("fox run", false);
        GetComponent<Animator>().SetBool("fox walk", true);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps < maxJumps)
        {
            isGrounded = false;
            jumps++;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("fox run", false);

        }

        /*Moves Left and Right*/
        if (Input.GetKey(KeyCode.RightArrow))//right
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            facingRight = true;
            GetComponent<Animator>().SetBool("fox run", true);
            GetComponent<Animator>().SetBool("fox walk", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))//left
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            facingRight = false;
            GetComponent<Animator>().SetBool("fox run", true);
            GetComponent<Animator>().SetBool("fox walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("fox walk", true);
            GetComponent<Animator>().SetBool("fox run", false);
        }

        Flip();
    }

    /*Flips Sprites On X-Axis Using SpriteRenderer Component*/
    private void Flip()
    {
        if (!facingRight)
            sr.flipX = true;
        else
            sr.flipX = false;
    }
}
