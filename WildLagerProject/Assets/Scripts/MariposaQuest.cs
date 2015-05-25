using UnityEngine;
using System.Collections;

public class MariposaQuest : MonoBehaviour 
{

	private bool questDone;
	private float distance;
	private Transform mariposa;
	private bool clickable;
	public Transform naru;

	// Use this for initialization
	void Start () 
	{
		mariposa = this.transform;
		questDone = false;
		clickable = false;
		distance = Vector3.Distance(mariposa.position, naru.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance (mariposa.position, naru.position);
		if (distance < 100 && questDone == false)
		{
			Debug.Log("Distancia de: "+distance);
			//SphereCollider zonaClick = mariposa.GetComponent<SphereCollider>();
			clickable = true;
		}
	}

	void onMouseClick(/*SphereCollider zonaClick*/)
	{
		if(Input.mousePosition)
		Debug.Log("Tio, tengo una mision para ti, haz feliz a Lidia :) ");

	}
}
