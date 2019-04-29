using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class GameManager : MonoBehaviour {

    public Transform platformGenerator; //Reference to the platformGenerator
    private Vector3 platformStartPoint; //The starting point of the platform generation

    public PlayerController thePlayer; //Reference to the playerController
    private Vector3 playerStartPoint; //The starting point of the player

    //Reference to the PlatformDestroyer and stores all the currently active platforms
    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager; //Reference to the ScoreManager

    public DeathMenu theDeathScreen; //Reference to the DeathMenu
    
	// Use this for initialization
	void Start () {
        //platformGenerator starts at the same position as the platformStartPoint
        platformStartPoint = platformGenerator.position;
        //thePlayer starts at the same position as the playerStartPoint
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>(); //Finds the ScoreManager
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame() //Restarts the game when the player dies
    {
        theScoreManager.scoreIncreasing = false; //Stops the score from increasing when the player is dead
        thePlayer.gameObject.SetActive(false); //Deactivates the player

        theDeathScreen.gameObject.SetActive(true); //Enables theDeathScreen 

        //StartCoroutine("RestartGameCo");
    }

    public void Reset() //Loads when the player clicks 'Restart'. Resets the current scene
    {

        theDeathScreen.gameObject.SetActive(false); //Disables theDeathScreen 
        //Finds all the current platforms which have 'PlatformDestroyer' attached to them
        platformList = FindObjectsOfType<PlatformDestroyer>();
        //Makes every platform turn inactive and then returns them to the object pool when the player dies
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        //Moves the player back to where playerStartPoint is located
        thePlayer.transform.position = playerStartPoint;
        //Moves the platformGenerator back to the platformStartPoint
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true); //Activates the player

        theScoreManager.scoreCount = 0; //Sets the scoreCount to 0
        theScoreManager.scoreIncreasing = true; //Starts the score increase
    }

    /*  public IEnumerator RestartGameCo() //Coroutine of RestartGame
    {
        theScoreManager.scoreIncreasing = false; //Stops the score from increasing when the player is dead
        thePlayer.gameObject.SetActive(false); //Deactivates the player
        //RestartGameCo will wait 0.5 seconds before moving thePlayer and platformGenerator back to their starting positions 
        yield return new WaitForSeconds(0.5f);

        //Finds all the current platforms which have 'PlatformDestroyer' attached to them
        platformList = FindObjectsOfType<PlatformDestroyer>();
        //Makes every platform turn inactive and then returns them to the object pool when the player dies
        for (int i = 0; i < platformList.Length; i++) 
        {
            platformList[i].gameObject.SetActive(false);
        }

        //Moves the player back to where playerStartPoint is located
        thePlayer.transform.position = playerStartPoint;
        //Moves the platformGenerator back to the platformStartPoint
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true); //Activates the player

        theScoreManager.scoreCount = 0; //Sets the scoreCount to 0
        theScoreManager.scoreIncreasing = true; //Starts the score increase 
    }   */
}
