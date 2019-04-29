using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool; //Reference to the ObjectPooler

    public float distanceBetweenCoins; //Sets the difference between coins

	public void SpawnCoins (Vector3 startPosition) //Spawns the coins
    {
        GameObject coin1 = coinPool.GetPooledObject(); //Uses the coin stored in the coinPool
        coin1.transform.position = startPosition; //Spawns the coin at the startPosition
        coin1.SetActive(true); //Activates the coin

        GameObject coin2 = coinPool.GetPooledObject(); //Uses the coin stored in the coinPool
        //Spawns the coin at a new position next to coin1
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z); 
        coin2.SetActive(true); //Activates the coin

        GameObject coin3 = coinPool.GetPooledObject(); //Uses the coin stored in the coinPool
        //Spawns the coin at a new position next to coin1
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true); //Activates the coin
    }
}
