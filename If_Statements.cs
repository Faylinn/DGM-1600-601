using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	public float score = 60f;

	void Start()
	{
		if (80f <= score) 
		{
			Debug.Log ("Awesome!");
		}
		else if (70f == score)
		{
			Debug.Log ("Almost Awesome");
		}
		else
		{
			Debug.Log ("Not Awesome");
		}
	}
}