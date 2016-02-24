using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    /* 
     * Variables:
     * A private Rigidbody variable
     * A public float for the speed
     * A public float for the direction
     */

    /*
     * The Start function:
     * Use GetComponent to get the rigidbody reference
     * Create a new Vector3 value for the direction variable with X and Z being zero and Y being a Random number between 0 and 360.
     * Assign the direction to the eulerAngles of this GameObject in order to rotate this GameObject
     */

	
    /*
     * The Update function:
     * Using the Rigidbody variable use AddRelativeForce and pass the forward direction times the speed as parameters
     */


    /* **************Explanation and Hints************
     * Rigidbody - When attached to a GameObject it adds things like gravity as well as other physics properties to the GameObject.
     *             For the player we want to attach the Rigidbody to it so that we can add a forward force to it when pressing the up arrow key
     *           - To use the Rigidbody we need a variable. The type of this variable is "Rigidbody" instead of "int" and often this variable
     *             is named "rigidbody".
     *           - Now we need to get the reference to the Rigidbody. If we don't then it won't work. In order to get the reference we need to
     *             type " *nameOfRigidbodyVariable* = GetComponentComponent<Rigidbody>(); " in the Start function. Replace *nameOfRigidbodyVariable*
     *             with whatever name you gave the rigidbody variable.
     *             
     * Vector3 - It's a variable that groups "x", "y", and "z" together. In this script we will be assigning a new Vector3 value with the random direction
     *           We'll do this by typing:
     *           *directionVariable* = new Vector(0, Random.Range(0, 360), 0);
     *           After we do with we'll want to assign this to the eulerAngles.
     *           
     * EulerAngles - There are two way to represent rotation in Unity. The first one is Quaternion and the second is EulerAngles. In this script we
     *               will be using the eulerAngles that's in transform since eulerAngles are easier to understand. Basically a eulerAngle is a
     *               Vector3 where the values of x, y, and z go from 0 to 360. So in this case if y has a value of 180 then this GameObject will
     *               be rotated 180 degrees on the y axis. In other words it will turn around. To assign a value to eulerAngles we'll type:
     *               transform.eulerAngles = *directionVariable*
     *               Replace *directionVariable* with the Vector3 direction variable that has a random value for the y axis.
     *              
     * AddRelativeForce - This will add a force relative to the direction of this GameObject. It is also a part of Rigidbody. In this script
     *                    we want to add force to the forward direction of this GameObject times the speed variable;
     *                  - We'll do this by typing:
     *                    *rigidbodyVariable*.AddRelativeForce(transform.forward * speed);
     */
	private Rigidbody rigidbody;
	public float speed;
	public Vector3 dir;

	void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody> ();
		dir = new Vector3 (0, Random.Range (0, 360), 0);
		transform.eulerAngles = dir;
	}

	void Update()
	{
		rigidbody.AddRelativeForce (transform.forward * speed);
	}
}
