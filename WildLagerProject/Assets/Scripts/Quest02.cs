using UnityEngine;
using System.Collections;

//Ejemplo de mision en la que hay que click X veces en un objeto para abrir un muro
public class Quest02 : MonoBehaviour
{
	private GameObject objetivoMision;
	private GameObject muro;	
	private Transform posicionObjetivo;
	private Transform posicionPlayer;
	private int cantidadObjetivo;
	private int cantidadActual;
	private bool misionActiva;
	private bool misionCompleta;
	private bool muroAbierto;
	private float distancia;
	private float i;

	void Start()
	{
		//Localizacion de objetos
		objetivoMision = GameObject.FindGameObjectWithTag("Mision01").gameObject;		
		muro = GameObject.FindGameObjectWithTag("Muro01").gameObject;
		posicionObjetivo = objetivoMision.GetComponent<Transform>();
		posicionPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
		distancia = Vector3.Distance(posicionPlayer.position,posicionObjetivo.position);

		//Asignacion de estados
		misionActiva = false;
		misionCompleta = false;
		muroAbierto = false;
		cantidadActual = 0;
		cantidadObjetivo = 2;
	}

	void Update()
	{
		//Calculamos la distancia entre el personaje y el objetivo
		distancia = Vector3.Distance(posicionPlayer.position,posicionObjetivo.position);

		//Condicion para completa la mision
		if(cantidadActual==cantidadObjetivo && misionCompleta == false) 
		{
			misionCompleta = true;
			GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerQuests>().Mision1Completa = true;
		}

		//Consecuencia de completar la mision
		if(misionCompleta==true && muroAbierto==false)
		{
			Vector3 movimiento = new Vector3(0,0.1f,0);
			Vector3 nuevaPos = muro.GetComponent<Transform>().position + movimiento;
			muro.GetComponent<Transform>().position = nuevaPos;	
			if(muro.GetComponent<Transform>().position.y >= 15f) muroAbierto = true;			
		}
	}

	void OnMouseDown()
	{
		//Si clickamos, aumentamos la cantidadActual
		if(misionActiva == true && misionCompleta == false && distancia < 5) cantidadActual++;
	}


	//GETTERS AND SETTERS
	public GameObject Objetivo {
		get {
			return objetivoMision;
		}
		set {
			objetivoMision = value;
		}
	}

	public int CantidadObjetivo {
		get {
			return cantidadObjetivo;
		}
		set {
			cantidadObjetivo = value;
		}
	}

	public int CantidadActual {
		get {
			return cantidadActual;
		}
		set {
			cantidadActual = value;
		}
	}

	public bool Activa {
		get {
			return misionActiva;
		}
		set {
			misionActiva = value;
		}
	}

	public bool Completa {
		get {
			return misionCompleta;
		}
		set {
			misionCompleta = value;
		}
	}
}