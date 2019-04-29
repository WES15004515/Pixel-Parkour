using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class MainMenu : MonoBehaviour {

    public string playEndlessRun; //Accesses the Endless Run scene

	public void PlayGame() //Starts the game by opening the Endless Run scene
    {
        SceneManager.LoadScene(playEndlessRun); //Loads the scene known as Endless Run
    }

    public void QuitGame() //Closes the game to desktop 
    {
        Application.Quit(); //The game stops running and closes
    }
}
