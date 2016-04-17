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

/*************************************************************************************************************************/

	/*
	* Additional Variables:
	* A private GameObject to hold a reference to the player
	* A private variable with the type being your Enemy Damage Script
	*/

	/*
	* Additional Lines in the Start Function:
	*      Use FindGameObjectWithTag with the player's tag in order to get the reference to the player - place this line above the ones that were there before
	*      Use GetComponent to get the reference to your enemy damage script - place this line above the ones that were there before
	*      If (the type variable in the enemy damage script is equal to the first enum constant in the enemy damage script) - place this if statement at the bottom of the function
	*          Move the line that sets a random direction into this If statement
	*/

	/*
	* Additional Lines in the Update Function:
	*      If (the type variable in the enemy damage script is equal to the second enum constant OR the third enum constant in the enemy damage script)
	*          Use the LookAt function with the player's transform.
	*/

	/* **************Explanation and Hints************ 
	*  Damage Script variable type - When we want to use functions and variables from another script we need to have a variable that uses the script
	*                                as the type. In this script we want to use the enemy damage script. So we would write it like this:
	*                                
	*                                private *enemyDamageScriptName* *enemyDamageVariableName*;
	*                                
	*                                Replace *enemyDamageScriptName* with the name of your enemy damage script. Replace *enemyDamageVariableName* with a name of 
	*                                your choosing. Please look at the Classes and Datatypes assignment for more details.
	*                                
	* Accessing variables in the enemy damage script - To do this we need to use the dot operator. Please look at the Scope and Access Modifier assignment as well
	*                                                  as the Classes and Datatypes assignment. 
	* 
	* FindGameObjectWithTag - This will find a GameObject with a specific tag. In this case we are using it to get a reference to the player.
	*                         You can do this by typing out the following
	*
	*                         *nameOfPlayerVariable* = GameObject.FindGameObjectWithTag("EnterPlayerTagHere");
	*                         
	*  GetComponent - This allows us to get a reference to a script that's attached to the same GameObject that this script is attached to. In this
	*                  script we want to get a reference to the enemy damage script. This can be done by typing the following:
	*                  
	*                  *enemyDamageVariableName* = GetComponent<*enemyDamageScriptName*>();
	*                  
	*                  Replace *enemyDamageScriptName* with the name of your enemy damage script. Replace *enemyDamageVariableName* with a name of 
	*                  your choosing. 
	*
	* Getting a reference to the enemy damage script - You can do this the same way as getting the rigidbody except you replace "rigidbody" for
	*                                                  the name of the script. For example:
	*                                                   
	*                                                  *enemyDamageVariableName* = GetComponent<*enemyDamageScriptName*>();
	*
	* Comparing the type of enemy - In order to figure out what type of enemy this is we need to use the enemy damage variable from above.
	*                               Then we use the dot operator to access the type variable in that script. After the double equals we need
	*                               to use the enemy damage variable once again to access the enum we are comparing the type to.
	*
	* LookAt - The LookAt function rotates this GameObject to face a target. In this case we want to rotate the enemy so that it is facing the player.
	*          We can do this by typing the following:
	*          
	*          transform.LookAt(*nameOfPlayerVariable*.transform);
	*/

	private Rigidbody rigidbody;
	public float speed;
	public Vector3 dir;
	private GameObject player;
	private EnemyDamage dmg;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		dmg = GetComponent<EnemyDamage> ();
		rigidbody = gameObject.GetComponent<Rigidbody> ();

		if (dmg.enemyType == EnemyDamage.Enemies.SQUARE) 
		{
			dir = new Vector3 (0, Random.Range (0, 360), 0);
		}

		transform.eulerAngles = dir;


	}

	void Update()
	{
		rigidbody.AddRelativeForce (transform.forward * speed);

		if (dmg.enemyType == EnemyDamage.Enemies.SPHERE || dmg.enemyType == EnemyDamage.Enemies.CYLINDER)
		{
			transform.LookAt (player.transform);
		}
	}
}
