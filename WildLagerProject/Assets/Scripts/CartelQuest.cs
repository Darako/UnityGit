using UnityEngine;
using System.Collections;

public class CartelQuest : MonoBehaviour 
{

	private bool questDone;
	private float distance;
	private Transform cartel;
	private Transform naru;
	private bool clickable;

	// Use this for initialization
	void Start () 
	{
//		clickable = false;
		cartel = this.GetComponent<Transform>();
		naru = GameObject.FindWithTag("Naru").GetComponent<Transform>();
		distance = Vector3.Distance(cartel.position, naru.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance (cartel.position, naru.position);

		if (distance < 250) clickable = true;
		else clickable = false;
	}

	void OnMouseDown()
	{
		if(clickable)
		{
			Debug.Log("Mira Lidia, ya clicko!");

		}
	}

	void giveQuest()
	{

	}

}
