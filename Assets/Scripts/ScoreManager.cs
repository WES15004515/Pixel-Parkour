using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class ScoreManager : MonoBehaviour {

    public Text scoreText; //Reference to the ScoreText
    public Text highScoreText; //Reference to the HighScoreText

    public float scoreCount; //The counter for the score
    public float highScoreCount; //The counter for the high score

    public float pointsPerSecond; //Points earnt through running 

    public bool scoreIncreasing; //Stops the player from earning points when they die

	// Use this for initialization
	void Start () {
        //Determines whether the highscore should be 0 or if it should have a value
        if (PlayerPrefs.HasKey("HighScore"))  
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore"); //Finds out what the highscore should be 
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(scoreIncreasing) //Stops the players score increasing if they are dead
        {
            //Multiplies the pointsPerSecond by every frame the player is alive
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        //Updates the high score if the current score is higher than the current high score
        if (scoreCount > highScoreCount) 
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount); //Saves the highscore
        }

        //Updates the ScoreText on the Canvas with the current score and rounds it to the nearest whole number
        scoreText.text = "Score: " + Mathf.Round (scoreCount); 
        //Updates the HighScoreText on the canvas with the current high score and rounds it to the nearest whole number
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount); 
		
	}

    public void AddScore(int pointsToAdd) //Recieves points from the PickupPoints script and adds the score to the player
    {
        scoreCount += pointsToAdd;
    }
}
