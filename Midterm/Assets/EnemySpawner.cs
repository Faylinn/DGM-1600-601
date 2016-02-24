using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    /* 
     * Variables:
     * A public array of GameObjects that holds the references to the enemy prefabs
     * A private float for the invoking delay
     */
	
    /*
     * The Start function:
     * Assign a value to the delay variable
     * Use InvokeRepeating to repeatedly call the spawn function. Put the name of the spawn function, 0, and the delay variable as parameters
     */

    /*
     * A function for spawning the enemies:
     * Create an int variable for the index and assign it zero.
     * Use a while loop. Check if the index variable is less then the size of the enemies array
     *      In the while loop create a new Vector3 variable and assign this GameObject's position to it
     *      Add the index variable to the x value of the Vector3 variable
     *      Instantiate the current enemy using the Vector3 variable and Quaternion.identity
     *      Increment the index variable
     */

    /* **************Explanation and Hints************
     * GameObject - They are the objects placed in a scene such as a Cube or an Empty Object. We also
     *              place these scripts on GameObjects.
     *              
     * Array - We will learn more about them later. For now it's important to know that they are
     *         a collection of things. In this script we want the array to contain the prefabs of the
     *         enemies. We need this so that we can instantiate them.
     *       - To make an array of the enemy prefabs we will type:
     *         public GameObject[] *nameOfArray*;
     *         Replace *nameOfArray* with your own name for the array;
     *       - To get the size of the array type:
     *         *nameOfArray*.Length
     *       - To get a value out of the array we need an index variable. We would type it out like this
     *         *nameOfArray*[*index*]
     *         Replace *nameOfArray* with the name you have given the array. Replace *index* with the name
     *         you have given the index.
     *         
     * index - It's an int variable that helps us get a value from the array with the index representing it's
     *         position of the value in the array.
     *         
     * Prefab - They are GameObjects that are stored outside of the scene. We use them to instantiate
     *          GameObjects.
     *          
     * InvokeRepeating - It is a special function that will call the specified function at a set interval.
     *                   In this script we want to do this so that enemies will spawn over and over again.
     *                 - Type this to use it:
     *                   InvokeRepeating("nameOfFunction", 0, *delayVariable*);
     *                   Replace nameOfFunction with the name of the spawning function. Be aware that when
     *                   typing in the name of the function we will put double quotes at the beginning
     *                   and end of the name in order to make it a string. Replace *delayVariable* with
     *                   the delay variable that we have created above.
     *     
     * Vector3 - It's a variable that groups "x", "y", and "z" together. To create a new Vector3 variable type:
     *           Vector3 *nameOfVariable* = new Vector3( *X-Value*, *Y-Value*, *Z-Value*);
     *           Replace *nameOfVariable* with any name you want to give it. Replace *X-Value*, *Y-Value*, or *Z-Value*
     *           with a float values or variables. In this script we will be assigning the position of this GameObject
     *           to a Vector3 variable
     * 
     * Position - In this script we need to find the position of the GameObject that this script is attached
     *            to. In order to do this we will type:
     *            transform.position
     *          
     * Instantiate - This will create a new GameObject or prefab of our choosing. In this script we want to
     *               use the array with an index, a position, and Quaternion.identity. 
     *             - To create the enemies we'll type:
     *               Instantiate(*nameOfArray*[*index*], *aVector3ForPosition*, Quaternion.identity);
     *               Replace *nameOfArray* with the name you have given the array. Replace *index* with the name
     *               you have given the index. Replace *aVector3ForPosition* with the Vector3 variable that has
     *               this GameObjects position.
     *               
     * Incrementing - This will increase the value of an int variable by one. It is typed like this:
     *                *intVariable*++;
     */
	// Looks in the EnemyPrefab folder and will put each prefab into the objs array
	public GameObject[] objs;
	private float delay;

	void Start()
	{
		delay = 3f;
		InvokeRepeating ("Spawn", 0f, delay);
	}

	void Spawn()
	{
		int index = 0;

		while (index < objs.Length)
		{
			Vector3 pos = gameObject.transform.position;
			pos.x += index * 5;
			Instantiate (objs[index], pos, Quaternion.identity);
			index++;
		}
	}
}