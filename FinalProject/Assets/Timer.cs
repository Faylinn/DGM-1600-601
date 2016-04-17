using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    /* 
     * Variables:
     * A public float for the amount of time
     */

    /*
     * The Update function:
     * Call the check timer function
     */

    /*
     * The check timer function:
     * Subtract the time variable with Time.deltaTime and assign it back into the time variable
     * If the time variable is less than zero then destroy this GameObject
     */
	
    /* **************Explanation and Hints************
     * deltaTime - deltaTime will give you the time that has passed since the last frame was rendered.
     *             What is important about this variable is that using this inside the Update function
     *             or a function that is called within the Update function will allow you to decrease or
     *             increase a value in real seconds. In this script we are using it as a timer to decrease
     *             the timer until it reaches zero.
     * Destroy - This function will destroy whatever GameObject we pass in as a parameter. For example we
     *           can type:
     *           Destroy(gameObject);
     *           This will destroy the GameObject that this script is attached to. For our project we want
     *           to use this along with the timer so that the enemies that have spawned don't stick around
     *           forever.
     */

	public float time;

	void Start()
	{
		//time = 9999f;
	}

	void Update ()
	{
		CheckTime ();
	}

	void CheckTime ()
	{
		time -= Time.deltaTime;

		if (time <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
