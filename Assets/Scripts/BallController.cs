using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb;
    static public bool canMoveFreely = false;
    public static bool moveLeft = true;
    private AudioSource ballBounce;
    public GameObject Player;
    static public bool isHit = false;
    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Bat");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        ballBounce = GetComponent<AudioSource>();
	}

    

    void Update()
    {
        Vector2 speed;
        speed.x = 0f;
        speed.y = 0f;
        if (canMoveFreely)
        {
            rb.isKinematic = false;

            if (moveLeft)
            {
                speed.x = -5;
                speed.y = 5;
            }
            else if (!moveLeft)
            {
                speed.x = 5;
                speed.y = 5;
            }          

            rb.velocity = new Vector2(speed.x, speed.y);
        }

        canMoveFreely = false;

        if (BatControllet.launchedBall)
        {
            if (isHit)
            {
                if (Player.GetComponent<Rigidbody2D>().velocity.x > 0.5f)
                {
                    rb.velocity = new Vector2(5f, 5f);
                    print("ima 1");
                    isHit = false;
                }
                else if (Player.GetComponent<Rigidbody2D>().velocity.x < -0.5f)
                {
                    rb.velocity = new Vector2(-5f, 5f);
                    print("ima 2");
                    isHit = false;
                }
                else
                {
                    rb.velocity = new Vector2(2f, 5f);
                    print("ima 3");
                    isHit = false;
                }
             
            }
        }


    }
    void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.gameObject.name == "Bottom")
        {
            if(GameManager.blockCount != 0)
            GameManager.lives--;


            rb.isKinematic = true;
            rb.velocity = new Vector2(0f, 0f);
            transform.localPosition = new Vector2(0f, 0.6f);
            BatControllet.launchedBall = false;
        }   
    }
    void OnCollisionEnter2D(Collision2D hit)
    {      
            ballBounce.Play();
        if (hit.gameObject.name == "Left" || hit.gameObject.name == "Right")
        {
            if (rb.velocity.x > 0f && rb.velocity.x != 5f)
            {
                rb.velocity = new Vector2(5f, rb.velocity.y);
            }
            if (rb.velocity.x < 0f && rb.velocity.x != -5f)
            {
                rb.velocity = new Vector2(-5f, rb.velocity.y);
            }

            if (rb.velocity.y > 0f && rb.velocity.y != 5f)
            {
                
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
            if (rb.velocity.y < 0f && rb.velocity.y != -5f)
            {
                
                rb.velocity = new Vector2(rb.velocity.x, -5f);
            }
        }
    }
}
