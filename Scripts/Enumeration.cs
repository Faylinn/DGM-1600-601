using UnityEngine;
using System.Collections;

public class Enumeration : MonoBehaviour
{
	enum animal{dog,cat, bird, fish};
	
	void Start()
	{
		animal myAnimal;
		myAnimal = animal.dog;
		myAnimal = changeAnimal (myAnimal);
		print (myAnimal);
	}
	
	animal changeAnimal(animal ani)
	{
		if(ani == animal.dog)
			ani = animal.cat;
		else if (ani == animal.cat)
			ani = animal.dog;
		return ani;
	}
}