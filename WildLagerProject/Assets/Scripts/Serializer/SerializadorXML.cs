using UnityEngine;
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization;


public class SerializadorXML<T> where T : class, new ()
{
	XmlSerializer serializer;
	//XmlSerializer deserializer;
	string resource;	string fich;
	/// <summary>
	/// Constructor para la serialización sin ficheros. Initializes a new instance of the <see cref="SerializadorXML`1"/> class.
	/// </summary>
	/// <param name='extraTypes'>
	/// Extra types.
	/// </param>
	public SerializadorXML(params Type[] extraTypes)
	{
		if (extraTypes != null && extraTypes.Length > 0)
		{
			serializer = new XmlSerializer(typeof(T), extraTypes);
		}
		else
		{
			serializer = new XmlSerializer(typeof(T));
		}
	}
	/// <summary>
	/// Constructor para la serialización con ficheros. Initializes a new instance of the <see cref="SerializadorXML`1"/> class.
	/// </summary>
	/// <param name='fich'>
	/// Fich.
	/// </param>
	/// <param name='resource'>
	/// Resource.
	/// </param>
	/// <param name='extraTypes'>
	/// Extra types.
	/// </param>
	public SerializadorXML(string fich, string resource, params Type[] extraTypes)
	{
		if (extraTypes != null && extraTypes.Length > 0)
		{
			serializer = new XmlSerializer(typeof(T), extraTypes);
		}
		else
		{
			serializer = new XmlSerializer(typeof(T));
		}
		this.fich = fich;
		this.resource = resource;
	}
	public void Serializar2XML(T elem)
	{
		TextWriter textWriter = new StreamWriter(fich);
		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
		serializer.Serialize(textWriter, elem, ns);
		textWriter.Close();	
	}
	public byte[] Serializar2BytesXML(T elem)
	{		
		MemoryStream stream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(stream);
		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
		serializer.Serialize(streamWriter, elem, ns);
		streamWriter.Close();	
		return stream.ToArray();
	}
	public string Serializar2StringXML(T elem)
	{		
		MemoryStream stream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(stream);
		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
		serializer.Serialize(streamWriter, elem, ns);
		streamWriter.Close();	
		byte[] buffer = stream.ToArray();
		return  Encoding.UTF8.GetString(buffer, 0, buffer.Length);;
	}
	public T DeserializarXML() {
		
		TextAsset textReaderAux = Resources.Load(resource) as TextAsset;
		byte[] byteArray = Encoding.UTF8.GetBytes(textReaderAux.text);
		MemoryStream stream = new MemoryStream(byteArray);
		TextReader textReader = new StreamReader(stream);
		T elem; 
		elem = (T)serializer.Deserialize(textReader);
		textReader.Close();
		textReader.Dispose();
		return elem; 
	}
	public T DeserializarBytesXML(byte[] byteArray) {
		
		MemoryStream stream = new MemoryStream(byteArray);
		TextReader textReader = new StreamReader(stream);
		T elem; 
		elem = (T)serializer.Deserialize(textReader);
		textReader.Close();
		textReader.Dispose();
		return elem; 
	}
	public override string ToString () {
		return "Recurso: \""+ resource + "\". Fichero: \"" + fich + "\".";
	}
}
