using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	void Start()
	{
		int cat = 4;
		
		while(cat > 0)
		{
			Debug.Log ("missing cats");
			cat--;
		}
		
		int dog = 3;
		
		do
		{
			Debug.Log("missing dogs");
		}while (dog ==7);
		
		int bird = 2;
		
		for(int x = 0; x < bird; x++)
		{
			Debug.Log ("missing birds");
		}
		
		int[] fish = new int[3];
		fish[0] = 6;
		fish[1] = 7;
		fish[2] = 2;
		
		foreach(int bubbles in fish)
		{
			Debug.Log(bubbles);
		}
	} 
}