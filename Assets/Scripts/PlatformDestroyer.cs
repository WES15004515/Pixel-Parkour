using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDestructionPoint; //Point where the platforms behind the player will be destroyed

	// Use this for initialization
	void Start () {
        //Finds any object that has "PlatformDestructionPoint" as the name 
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
        //Determines whether the position the platform is in requires the platform to be destroyed or not
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {

            //Destroy(gameObject); //Destroys the platform

            gameObject.SetActive(false); //Deactivates the platform

        }

	}
}
