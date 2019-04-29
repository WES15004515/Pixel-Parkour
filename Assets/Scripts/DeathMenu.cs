using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel; //Allows the script to access the Main Menu scene

    public void RestartGame() //Restarts the current scene 
    {
        FindObjectOfType<GameManager>().Reset(); //Finds the GameManager and calls the Reset function
    }

    public void QuitToMain() //Loads the Main Menu scene
    {
        SceneManager.LoadScene(mainMenuLevel); //Loads the scene known as Main Menu
    }
}
