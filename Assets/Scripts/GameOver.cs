using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public Text Final_Score;
    public Text points;
    public Text lives;

    private int livesCount = 0;
    private int pointsCount = 0;
    private int finalScoreCoutn = 0;
    // Use this for initialization
    void Start () {
        livesCount = GameManager.lives;
        pointsCount = GameManager.score;
        if (livesCount <= 0)
            livesCount = 0;
        finalScoreCoutn = pointsCount + (livesCount * 250);
  
	}
	
	// Update is called once per frame
	void Update () {
        Final_Score.text = finalScoreCoutn.ToString();
        points.text = pointsCount.ToString();
        lives.text = livesCount.ToString();
	}

    public void ResetGame()
    {
        GameManager.lives = 3;
        GameManager.score = 0;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
