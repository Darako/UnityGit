/// <copyright company="Athagon Studios" file="ASSingleton.cs">
///   Disclaimer:
///   (C) 2013 Athagon Studios   <A HREF="http://www.athagon.com">	<support@athagon.com>
///   All rights reserved.  No part of this code can be distributed in
///   any form, without previous written consent of the copyright owner.
///   This code is distributed WITHOUT ANY WARRANTY, even the implied
///   WARRANTY OF MERCHANTABILITY or FITNESS FOR ANY PARTICULAR PURPOSE.
///   In case of an agreed previous, written contract, the WARRANTIES
///   applied will be the ones written in the applicable contract.
/// </copyright>
/// <remarks>
/// <author>German Caballero</author>
/// <date>2012</date>
using System;
using System.Reflection;

using UnityEngine;

/// <summary>
/// Instancia unica.
/// Implementación de un template que asegura que
/// sólo puede existir una instancia en las clases
/// que hereden de aquí.
/// ver <seealso cref="http://stackoverflow.com/questions/380755/a-generic-singleton"/>
/// </summary>
public class ASSingleton<T> where T : class, new()
{		
	/// <summary>
	/// Puntero volatil (varios subprocesos que se ejecutan a la vez pueden modificar este campo)
	/// a la instancia
	/// </summary>
	private static volatile  T instancia;
	
	private static object bloqueador = new System.Object();
	
	/// <summary>
	/// Propiedad que devuelve la instancia única.
	/// </summary>
	/// <value>
	/// The instancia.
	/// </value>
	public static T Instancia
	{
		get{
			if (instancia == null)
			{
				CrearInstancia();
			}
			return instancia;
		}		
	}
	/// <summary>
	/// Crear la instancia única.
	/// Nos aseguramos que no hay una instancia ya creada
	/// y que no hay constructores públicos y en
	/// caso positivo creamos la instancia única.
	/// </summary>
	private static void CrearInstancia()
	{		
		lock (bloqueador)
		{
			if (instancia == null)
			{
				instancia = new T();
			}
		}
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="ASSingleton`1"/> class.
	/// Be carful, you can use it.
	/// </summary>
	ASSingleton()
	{
	}
}
