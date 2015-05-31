using UnityEngine;
using System.Collections;

//Nos dara la mision
public class Cartel01Quest : MonoBehaviour 
{	
	private Transform cartelPosicion;
	private Transform jugadorPosicion;
	private float distancia;
	private bool clickable;
	private bool mision01Asignada;
	private bool mision01Completa;

	void Start () 
	{		
		cartelPosicion = this.GetComponent<Transform>();
		jugadorPosicion = GameObject.FindWithTag("Player").GetComponent<Transform>();
		distancia = Vector3.Distance(cartelPosicion.position, jugadorPosicion.position);
		clickable = false;
		mision01Asignada = false;
	}
	
	void Update () 
	{	
		//si la distancia es menor a 250, permitimos que se pueda clickar, para entregar la mision
		distancia = Vector3.Distance (cartelPosicion.position, jugadorPosicion.position);
		if (distancia < 250) clickable = true; else clickable = false;
	}

	void OnMouseDown()
	{	
		//si es clickable(distancia<250) y aun no se asigno ninguna mision, se asigna
		if(clickable && mision01Asignada == false)
		{
			GameObject player = GameObject.FindWithTag("Player").gameObject;
			player.GetComponent<PlayerQuests>().Mision1Activa = true;
			mision01Asignada = true;
		}
	}


}
