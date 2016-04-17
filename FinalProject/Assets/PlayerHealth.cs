using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    /* 
     * Variables:
     * A public Text for the health text
     * A private int for the health
     * A private int for the damage amount
     */


	/*
     * The Start function:
     * Set the initial value for the health variable
     * Set the initial value for the damage variable
     */


    /*
     * The OnCollisionEnter function:
     * If the tag of the Collision parameter equals the enemy tag then
     *      -Call the damage function with the health variable as a parameter 
     *       and save the return value to the health variable
     *      -Show the current value of the health variable by saving it to the
     *       text value of the "health text" variable
     * Else if the tag of the Collision parameter equals the kill zone tag then
     *      -Reload the level
     */


    /* 
     * A function that will reduce the health of the player when there is damage
     * The return type is int and the parameter is an int
     * Create a variable for the new health value
     * The value of that variable will be the parameter variable minus the damage variable
     * If the new health value is less than 0 reload the level
     * Lastly, return the new health variable
     */

    /* **************Explanation and Hints************
     * Text - The Text component is used for UI text. In this script we want to display the current health on the
     *        screen. Using Text will help us do that. First of all you'll need to type "using UnityEngine.UI; " at
     *        the very top of the script. Then we need to have a Text variable. By itself the Text variable can't do
     *        anything. We need to assign the a Text reference to it. We can do it by making the Text variable public
     *        then in the inspector we can drag the Text object into our Text variable.
     *      - To change what The Text variable displays we need to type " *textVariableName*.text = *intOrStringVariable*;"
     *        Replace *textVariableName* with the name of the Text variable and replace *intOrStringVariable* with an int
     *        or string variable.
     * OnCollisionEnter - This is a special Unity function. It runs whenever a GameObject with rigidbody attached to it
     *                    runs into another object. In this script we are using it to detect when the player runs into
     *                    an enemy or the kill zone. One thing this function needs is a Collision parameter. The collision
     *                    parameter is useful because it gives us the reference of whatever the player hits. The function
     *                    is typed like this: 
     *                    void OnCollisionEnter(Collision *name*)
     *                    {
     *                        //Run code here
     *                    }
     *                    Replce *name* with what you want to call the Collision variable
     * Tag - Tags are used to identify GameObjects. In the inspector we can create new tags and set tags for GameObjects.
     *       In this project we will want to create two tags. First one is "Enemy" and the second one is "KillZone". Then
     *       we want to give the enemies the "Enemy" tag, give the player the "Player" tag, and give the KillZone the
     *       "KillZone" tag.
     *     - In the OnCollisionEnter function we will type If statements. The conditionals of these if statements will be
     *       comparing the passed in Collision variable's tag with the strings "Enemy" or the KillZone. We do this so
     *       we know what the player has hit. You will type out these If statements in the OnCollisionEnter function
     *       like this:
     *       If(*collisionVariable*.transform.tag == *stringOfTag*)
     *       {
     *          //Do stuff when this hits an GameObject with the tag specified above
     *       }
     *       Replace *collisionVariable* with the name that you have given the Collision variable. Replace *stringOfTag*
     *       with either the "Enemy" tag or the "KillZone" tag.
     * LoadLevel - This function belongs in the Application object which contains variable and functions about our game.
     *             We will use this to make it so that when the player hits the KillZone or looses all of it's health
     *             then we will start the level over again.
     *           - Before we can load a level we need to add our scene to the Build list. We can do this by going to
     *             File->Build Settings->Add current. This will add our current scene to the build list. Then, as a
     *             parameter, we will pass in the name of the scene or the index of the scene. Since we just have one
     *             scene you can pass in a zero.
     *           - LoadLevel is typed like this:
     *             Application.LoadLevel(*nameOrIndexOfScene*);
     *             Replace *nameOrIndexOfScene* with the name of the scene you want to load or it's index. You'll 
     *             probably want to pass in a zero.
     */

	public Text healthText;
	private int health;
	private int damage;

	void Start()
	{
		health = 25;
		damage = 5;
		healthText.text = health.ToString ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Enemy") 
		{
			health = Damage (health, damage);
			healthText.text = health.ToString();
		} 
		else if (col.transform.tag == "KillZone") 
		{
			//Application.LoadLevel (0);  // This is depreciated don't use this
			SceneManager.LoadScene(0);
		}
	}

	int Damage(int h, int d)
	{
		int newHealth = h - d;

		if (newHealth <= 0) 
		{
			//Application.LoadLevel (0);  // This is depreciated don't use this
			SceneManager.LoadScene(0);
		}
		return newHealth;
	}
}
