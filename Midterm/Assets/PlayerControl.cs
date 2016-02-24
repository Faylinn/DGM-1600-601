using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    /* 
     * Variables:
     * A public float for rotation speed
     * A public float for movement speed
     * A private Rigidbody
     */

    /*
     * The Start function:
     * Use GetComponent to get the rigidbody reference
     */

	/*
     * The Update function:
     * If the leftArrow is pressed then rotate the player to the left
     * Else if the right arrow is pressed then rotate the player to the right
     * If the upArrow is pressed then use AddRelativeForce to move forward
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
     * Key inputs - In order to detect key presses Unity has a special Object called Input. We will have to put this Input object as a conditional
     *              of an if statement. We do this so that when a key is pressed it will only run the code in the if statement. Input also has to
     *              be in the Update function. So if we wanted to detect the left arrow key we would type the following in the Update function:
     *              "if(Input.GetKey(KeyCode.LeftArrow))
     *              {
     *                  //Put here what you want the left arrow to do
     *              }"
     *              
     * Rotation - To rotate the player we need to use a function in the Transform object. Transform contains all of the variables and functions
     *            relating to a GameObject's position and rotation. So if we want the player to turn left or right we would type the following.
     *            " transform.Rotate(new Vector3(0, *rotationSpeedVariable*, 0); ". Replace *rotationSpeedVariable* with whatever variable you
     *            are using for the rotation speed.
     *            
     * Forward movement - There are many ways to move a GameObject but in this instance we will use the AddRelativeForce function. That function
     *                    is a part of the Rigidbody component. AddRelativeForce adds a force in a direction relative to the rotation of the
     *                    GameObject. Also, make sure that the Rigidbody variable has a reference or else Unity will throw an error. So to add
     *                    forward movement to the player we need to type the following:
     *                    " *nameOfRigidbodyVariable*.AddRelativeForce(0, 0, *movementSpeedVariable*); ". Replace *nameOfRigidbodyVariable* with
     *                    the name of the Rigidbody variable and replace *movementSpeedVariable* with the name of the movement speed variable.
     */

	public float rotation;
	public float movement;
	private Rigidbody rigidbody;

	void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody> ();
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Rotate (new Vector3 (0, -rotation, 0));
		} 
		else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Rotate (new Vector3 (0, rotation, 0));
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			rigidbody.AddRelativeForce (0, 0, movement);
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			rigidbody.AddRelativeForce (0, 0, -movement);
		}
	}
}
