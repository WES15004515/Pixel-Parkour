using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class PickupPoints : MonoBehaviour {

    public int scoreToGive; //Score that is given to the player 

    private ScoreManager theScoreManager; //Reference to the ScoreManager

    private AudioSource coinSound; //The sound of the coin when the player collects it

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>(); //Finds the ScoreManager

        //Finds the GameObject 'CoinSound' and the AudioSource connected to it
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //When the player enters the trigger zone, award the player will additional points towards their score
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive); //Awards the player will the value of scoreToGive
            gameObject.SetActive(false); //Sets the coin to inactive

            if(coinSound.isPlaying) //Prevents the coin sound from being cut off by other coin sounds
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }

            coinSound.Play(); //Plays the coinSound
        }
    }
}
