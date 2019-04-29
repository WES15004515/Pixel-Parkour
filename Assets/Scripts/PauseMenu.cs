using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel; //Allows the script to access the Main Menu scene

    public GameObject pauseMenu; //Allows the player to activate and deactivate the Pause Menu

    public void PauseGame() //Pauses the current scene
    {
        Time.timeScale = 0f; //Time will stop 
        pauseMenu.SetActive(true); //Turns the Pause Menu on
    }

    public void ResumeGame() //Resumes the current scene 
    {
        Time.timeScale = 1f; //Time will continue as intended
        pauseMenu.SetActive(false); //Turns the Pause Menu off
    }

    public void RestartGame() //Restarts the current scene 
    {
        Time.timeScale = 1f; //Time will continue as intended
        pauseMenu.SetActive(false); //Turns the Pause Menu off
        FindObjectOfType<GameManager>().Reset(); //Finds the GameManager and calls the Reset function
    }

    public void QuitToMain() //Loads the Main Menu scene
    {
        Time.timeScale = 1f; //Time will continue as intended
        SceneManager.LoadScene(mainMenuLevel); //Loads the scene known as Main Menu
    }
}
