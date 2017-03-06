using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    private int blockHealth;
    private int scoreMultiplier = 1;

	// Use this for initialization
	void Start () {
        GameManager.blockCount++;
      
        switch (gameObject.tag)
        {
            case "Red":
                blockHealth = 1;
                scoreMultiplier = 1;
                break;
            case "Yellow":
                blockHealth = 1;
                scoreMultiplier = 1;
                break;
            case "LightBlue":
                blockHealth = 2;
                scoreMultiplier = 3;
                break;
            case "Green":
                blockHealth = 2;
                scoreMultiplier = 3;
                break;
            case "Blue":
                blockHealth = 3;
                scoreMultiplier = 5;
                break;
            case "Purple":
                blockHealth = 3;
                scoreMultiplier = 5;
                break;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "Ball")
        {
            blockHealth--;
        }
       
    }
    void OnCollisionExit2D()
    {
        if (blockHealth <= 0)
        {
            GetComponentInParent<AudioSource>().Play();
            GetComponentInParent<ParticleSystem>().Emit(15);
            GameManager.score += 100 * scoreMultiplier;
            GameManager.blockCount--;
            Destroy(gameObject);
        }

        if (GameManager.score >= GameManager.newLife)
        {
            GameManager.lives++;
            GameManager.newLife *= 2;
        }
    }
}
