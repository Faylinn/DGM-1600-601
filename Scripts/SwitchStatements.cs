using UnityEngine;
using System.Collections;

public class SwitchStatements : MonoBehaviour 
{
	public int cats = 3;
	
	void Start()
	{
		switch(cats)
		{
			case 3:
				print ("Too many cats");
				break;
			case 2:
				print ("Great amount of cats");
				break;
			case 1:
				print ("Your cat needs a friend");
				break;
			case 0:
				print ("Do you need a cat?");
				break;
			default:
				print ("You crazy cat person!");
				break;
		}
	}
}