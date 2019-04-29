using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/


public class BackgroundScroller : MonoBehaviour {

	public float speed = 0.0f; //This is the speed the background scrolls at
	public Transform player; //This is the players transform

	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(player.position.x * speed, 0.0f )); //Sets the background position based on the player position
	}
}
