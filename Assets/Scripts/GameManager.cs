using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public Text scoreCount;
    public Text livesCount;
    static public int newLife = 0;
    static public int score = 0;
    static public int lives = 3;
    static public int blockCount = 0;
    static public int levelNum = 0;

    private float seconds;
    private SpriteRenderer rend;
    private float alpha = 0f;

	// Use this for initialization
	void Start () {
        newLife = 2500;
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    
	void Update () {
        rend.color = new Vector4(0f, 0f, 0f, alpha);

        if (blockCount == 0 || lives <= -1)
        {
          
            seconds += Time.deltaTime;
            alpha += Time.deltaTime * 0.5f;
            if (seconds >= 2)
            {
                levelNum++;
                BatControllet.launchedBall = false;
                if (lives <= -1)
                {
                    SceneManager.LoadScene(3);
                }
                else
                {
                    SceneManager.LoadScene(levelNum);
                }
            }               
        }
        else
        {
            seconds = 0f;
        }
        scoreCount.text = score.ToString();
        livesCount.text = lives.ToString();
	}
}
