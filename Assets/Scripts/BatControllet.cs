using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControllet : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 5;
    static public bool launchedBall = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!BallController.canMoveFreely)
                BallController.moveLeft = true;  
             
            rb.velocity = new Vector2(-1f, 0f) * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(!BallController.canMoveFreely)
                BallController.moveLeft = false;

            rb.velocity = new Vector2(1f, 0f) * speed;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        if (Input.GetKey(KeyCode.Space) && !launchedBall)
        {
            BallController.canMoveFreely = true;
            launchedBall = true;
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "Ball")
        {
            BallController.isHit = true;
        }
    }
}
