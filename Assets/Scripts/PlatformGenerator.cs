using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform; //Platform that will be generated when needed
    public Transform generationPoint; //Point of platform generation
    public float distanceBetween; //Distance between platforms

    private float platformWidth; //How wide the platform is  

    public float distanceBetweenMin; //Minimum distance between platforms
    public float distanceBetweenMax; //Maximum distance between platforms

    //public GameObject[] thePlatforms; //The Collection of available platforms
    private int platformSelector =-1; //Selects a platform to be generated
    private float[] platformWidths; //The widths between each platform

    public ObjectPooler[] theObjectPools; //Reference to the ObjectPooler

    private float minHeight; //Minimum height of generated platforms
    public Transform maxHeightPoint; //Point for the maximum height of generated platforms
    private float maxHeight; //Maximum height of generated platforms
    public float maxHeightChange; //The maximum height change of generated platforms
    private float heightChange; //The possible height change of generated platforms

    private CoinGenerator theCoinGenerator; //Reference to the CoinGenerator
    public float randomCoinThreshold; //Threshold that prevents the creation of coins

	// Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //Sets platform width to the same width as the box collider

        platformWidths = new float[theObjectPools.Length]; //Sets the width between each platform 

        for (int i = 0; i < theObjectPools.Length; i++) //If i is less than the platforms length, then plus 1 to i value
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x; //platformWidths equals the same as thePlatforms x axis
        }

        minHeight = transform.position.y; //Sets the minHeight position
        maxHeight = maxHeightPoint.position.y; //Sets the maxHeight position

        theCoinGenerator = FindObjectOfType<CoinGenerator>(); //Finds the CoinGenerator
	}
	
	// Update is called once per frame
	void Update () {

        //Generates new platforms if the current x position is smaller than the generation point x position
        if (transform.position.x < generationPoint.position.x +20.0f) 
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax); //Chooses a random distance between the set minimum and maximum distance between platforms

            //Sets a variable length for the platform array. Selects any platform from 0 to 3
            platformSelector = Random.Range(0, theObjectPools.Length);

            //Takes the current height and then randomises it for the next platform
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            
            //Sets the heightChange to the same as the maxHeight or minHeight if heightChange value is too high or low
            if (heightChange > maxHeight) 
            {
                heightChange = maxHeight;
            }

            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //Moves the spawn position into a position where it will not interfere with any existing platforms
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)  + distanceBetween, heightChange, transform.position.z);

            //Instantiate(/*thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation); //Copies an existing platform and places it 

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject(); //newPlatform is equal to one of the objects in the object pool

            newPlatform.transform.position = transform.position; //Platform will activate at the set position
            newPlatform.transform.rotation = transform.rotation; //Platform will activate at the set rotation 
            newPlatform.SetActive (true); //Activates the platform 

            //Randomly selects a number and then spawns a coin if that number is less than the randomCoinThreshold
            if (Random.Range(0f, 100f) < randomCoinThreshold)   
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)); //spawns the coins on the top of the platform
            }
            //Moves the spawn position into a position where it will not interfere with any existing platforms
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2),transform.position.y, transform.position.z);

        }

    }
}
