using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Jugador que recibe la mision
public class PlayerQuests : MonoBehaviour 
{
	private GameObject objetivoMision;	
	private GameObject mision01;
	private Transform posicionObjetivo;
	private Transform posicionPlayer;
	private bool mision01Completa;
	private bool mision01Activa;
	
	void Start () 
	{
		mision01 = GameObject.FindGameObjectWithTag("Mision01").gameObject;
		posicionPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		mision01Completa = false;
		mision01Activa = false;
	}

	void Update () 
	{
		//Comprobamos si se ha activado una mision, y le pasamos la informacion a la propia mision
		if(mision01Activa == true && mision01.GetComponent<Quest01>().Activa == false) mision01.GetComponent<Quest01>().Activa = true;
		//Comprobamos si la mision se ha completado, y le pasamos la informacion al jugador
		if(mision01Activa == true && mision01.GetComponent<Quest01>().Completa == true) mision01Completa = true;
	}


	//GETTER AND SETTER
	public bool Mision1Completa {
		get {
			return mision01Completa;
		}
		set {
			mision01Completa = value;
		}
	}	

	public bool Mision1Activa {
		get {
			return mision01Activa;
		}
		set {
			mision01Activa = value;
		}
	}
}
