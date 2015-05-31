using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
[XmlRoot("Estructura")]
public class Estructura {
	
	[XmlAttribute]
	public float flotante;
	[XmlAttribute]
	public int entero;

	public string cadena;

	[System.Xml.Serialization.XmlIgnore]
	int ignorar;
	public Estructura (float flotante, int entero, string cadena, int ignorar)
	{
		this.flotante = flotante;
		this.entero = entero;
		this.cadena = cadena;
		this.ignorar = ignorar;
	}
	public Estructura() {
	}
		
	[System.Xml.Serialization.XmlIgnore]
	int Ignorar {
		get {
			return this.ignorar;
		}
		set {
			ignorar = value;
		}
	}
}
[System.Serializable]
[XmlRoot("ArrayEstructura")]
public class ArrayEstructura {
	public Estructura[] array;
}

public class PruebaSerializacion : MonoBehaviour {

	public ArrayEstructura datos;
	public SerializadorXML<ArrayEstructura> serializador;

	// Use this for initialization
	void Start () {
		serializador = new SerializadorXML<ArrayEstructura>();

		string datosSer = serializador.Serializar2StringXML(datos);
		Debug.Log(datosSer);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
