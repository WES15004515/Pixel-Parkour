using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class CameraController : MonoBehaviour {

    public PlayerController thePlayer; //Accesses the PlayerController script so the camera can use it 

    private Vector3 lastPlayerPosition; //Stores the position of the player
    private float distanceToMove; //Move the camera by a set amount when the player is moving

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>(); //Finds the player and allows the camera to use it
        lastPlayerPosition = thePlayer.transform.position; //Keeps track of the players position 
    }
	
	// Update is called once per frame
	void Update () {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //Determines the distance the player has travelled since last frame

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z); //Moves the camera to constantly follow the player on the x axis

        lastPlayerPosition = thePlayer.transform.position; //Keeps constant track of the players position 
	}
}
