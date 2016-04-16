using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject[] hero;
	
	void Start()
	{
		hero = GameObject.FindGameObjectsWithTag("Player");
		
		for(int x = 0; x < hero.Length; x++)
		{
			Debug.Log("Player "+x+"'s name is "+hero[x].name);
		}
	}
}