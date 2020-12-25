using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*il comenteret barcha bach tkon fahimni fach 9a3id na3mil*/
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;//default is 8
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float jumpForce = 30f;//default is 30
    [SerializeField] private int maxJumps = 2;//default is 2
    [SerializeField] private int level = 0;
    [SerializeField] private int point = 0;
    [SerializeField] private bool isGrounded = true;//Checks if player is touching the ground - default true
    private int jumps = 0;//the amount of jumps player has done
    public Text levelText;//the score number text
    public Text pointText;
    public Text winText;
    public Text winpointText;
    Rigidbody2D rb;//the player's rigidbody


    // Start is called before the first frame update
    void Start()
    {
        /*Get Components - SpriteRenderer & Rigidbody2D*/
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = level.ToString();
        pointText.text = point.ToString();
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
    private void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.tag == "score")
        {
            level++;//Increment score
            Debug.Log(level);//Show the score in the console
            Debug.Log("Increase Score!");//dima hot faza kif haka fi kol foc
            levelText.text = level.ToString();
        }
        if (col.gameObject.tag == "coin")
        {
            point++;//Increment score
            Debug.Log(point);//Show the score in the console
            Debug.Log("coin-");//dima hot faza kif haka fi kol foc
            pointText.text = point.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "win")
        {
            Debug.Log("win");
            winText.text = "you win!!";
            winpointText.text = "you have " + point + " points out of 47 point";
        }
    }
}
