using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject; //GameObject that is being pooled

    public int pooledAmount; //Amount of objects being automatically pooled

    List<GameObject> pooledObjects; //List of pooled objects

    

	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>(); //Creates a new list of GameObjects

        for(int i = 0; i < pooledAmount; i++) //Adds 1 to i whenever i is less than the pooledAmount
        {
            //Casts the pooledObject into a GameObject and fills the list with the number of pooledAmount
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false); //Deactivates the object
            pooledObjects.Add(obj); //add the obj object to the list of pooled objects
        }
		
	}
	
	public GameObject GetPooledObject() //Looks for a GameObject and uses a PooledObject
    {
        //Adds 1 to i whenever i is less than the pooledAmount. Uses an object that is not active
        for (int i = 0; i <pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy) //Checks to see if the pooledObjects are active in the Hierarchy
            {
                return pooledObjects[i]; //Returns the next inactive object
            }
        }

        //Casts the pooledObject into a GameObject and fills the list with the number of pooledAmount
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false); //Deactivates the object
        pooledObjects.Add(obj); //add the obj object to the list of pooled objects
        return obj; //Returns the obj object

    }
}
