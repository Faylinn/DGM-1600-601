using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
	/*
	* Variables:
	* A private Rigidbody to hold the reference to the Rigidbody component
	* A public float for bullet speed
	* A private int for weak damage
	* A private int for strong damage
	* A private int for super strong damage
	*/

	/*
	* The Start function, void return type, no parameters
	*      Use GetComponent to get the rigidbody reference
	*      Assign a value to the weak damage variable 
	*      Assign a value to the strong damage variable 
	*      Assign a value to the super strong damage variable 
	*/

	/*
	* The Update function, void return type, no parameters
	*      Using the Rigidbody variable call AddForce and pass the forward direction times the speed as parameters
	*/

	/*
	* The OnTriggerEnter function, void return type, parameter: Collider ***Please note that this is different then the others***
	*      If (tag of the Collider parameter equals the enemy tag) 
	*          -Create a variable with the type EnemyDamage and use the GetComponent in the Collider parameter to get a referece
	*               to the EnemyDamage script.
	*          -Create a switch statement in which you'll put the enemy type variable in the EnemyDamage script into the parenthesis
	*              -A case for the first enemy type
	*                  -Call the Damage function from the EnemyDamage script and pass the weak damage variable into it
	*              -A case for the second enemy type
	*                  -Call the Damage function from the EnemyDamage script and pass the strong damage variable into it
	*              -A case for the third enemy type
	*                  -Call the Damage function from the EnemyDamage script and pass the super strong damage variable into it
	*          -Destroy this bullet ***Make sure that this is included in the if statement***
	*/


	/* **************Explanation and Hints************
	* void - This is a return type. This means that a function will not return anything. To use this we will type
	*        "void" before the name of the function when we are writing out the whole function.
	*
	* Rigidbody - When attached to a GameObject it adds things like gravity as well as other physics properties to the GameObject.
	*             For the bullet we want to attach the Rigidbody to it so that we can add a forward force to it when shooting it
	*           - To use the Rigidbody we need a variable. The type of this variable is "Rigidbody" instead of "int" and often this variable
	*             is named "rigidbody".
	*           - Now we need to get the reference to the Rigidbody. If we don't then it won't work. In order to get the reference we need to
	*             type in the Start function:
	*             
	*              *nameOfRigidbodyVariable* = GetComponent<Rigidbody>(); 
	*              
	*             Replace *nameOfRigidbodyVariable* with whatever name you gave the rigidbody variable.
	*                    
	* OnTriggerEnter - This is a special Unity function. It runs whenever a GameObject whose Box Collider is mark as being a trigger.
	*                  This means that when the bullet runs into another GameObject that has a rigidbody it will call this function.
	*                  Triggers are useful because they allow you to know when two things hit eachother without using any physics.
	*                  The parameter is useful because it gives us the reference of whatever the bullets hits. The function
	*                  is typed like this:
	* 
	*                    void OnTriggerEnter(Collider *name*)
	*                    {
	*                        //Run code here
	*                    }
	*
	*                    Replce *name* with what you want to call the Collision variable
	*
	* AddForce - This will add a force in the direction that is provided. It is also a part of Rigidbody. In this script
	*            we want to add force to the forward direction of this GameObject times the speed variable;
	*          - We'll do this by typing:
	*                  
	*                    *rigidbodyVariable*.AddForce(transform.forward * speed);
	*
	* Tag - Tags are used to identify GameObjects. In the inspector we can create new tags and set tags for GameObjects.
	*       In this project we will want to create two tags. First one is "Enemy" and the second one is "KillZone". Then
	*       we want to give the enemies the "Enemy" tag, give the player the "Player" tag, and give the KillZone the
	*       "KillZone" tag.
	*     - In the OnTriggerEnter function we will type an If statements. The conditional of this if statements will be
	*       comparing the passed in Collider variable's tag with the string "Enemy". We do this so
	*       we know what the bullet has hit. You will type out this If statements in the OnTriggerEnter function
	*       like this:
	*
	*       If(*colliderVariable*.transform.tag == "Write the tag here")
	*       {
	*          //Do stuff when this hits an GameObject with the tag specified above
	*       }
	*
	*       Replace *colliderVariable* with the name that you have given the Collider variable. Replace *stringOfTag*
	*       with either the "Enemy" tag.
	*
	* Destroy - This function will destroy whatever GameObject we pass in as a parameter. For example we
	*           will type:
	*           
	*           Destroy(gameObject);
	*           
	*           This will destroy the GameObject that this script is attached to.
	*/

	private Rigidbody rigidbody;
	public float speed;
	private int weakDamage;
	private int strongDamage;
	private int superStrongDamage;

	void Start()
	{
		rigidbody = gameObject.GetComponent<Rigidbody> ();
		weakDamage = 5;
		strongDamage = 10;
		superStrongDamage = 15;
	}

	void Update()
	{
		rigidbody.AddForce (transform.forward * speed);
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.transform.tag == "Enemy") 
		{
			EnemyDamage enemyDamage = c.GetComponent<EnemyDamage> ();

			switch (enemyDamage.enemyType) 
			{
			case EnemyDamage.Enemies.SQUARE:
				enemyDamage.Damage (weakDamage);
				break;
			case EnemyDamage.Enemies.SPHERE:
				enemyDamage.Damage (strongDamage);
				break;
			case EnemyDamage.Enemies.CYLINDER:
				enemyDamage.Damage (superStrongDamage);
				break;
			}

			Destroy (gameObject);
		}
		else if (c.transform.tag == "KillZone") 
		{
			Destroy (gameObject);
		}
	}
}
