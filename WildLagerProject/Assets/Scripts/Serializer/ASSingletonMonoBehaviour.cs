/// <copyright company="Athagon Studios" file="ASSingletonMonoBehaviour.cs">
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
using UnityEngine;
 
//[ExecuteInEditMode]
/// <summary>
/// This class is a singleton. Only one instance of this class can exist.
/// </summary>
public class ASSingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    private static T instance;
 
    /// <summary>
    /// The singleton instance of this class.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            { 
                instance = (T)FindObjectOfType(typeof(T));
 
                if (instance == null)
                {
                    instance = CreateSingletonInstance<T>();
                }
            } 
            return instance;
        }
    }
 
    /// <summary>
    /// Create a gameobject with itself attached.
    /// </summary>
    /// <returns>Return an instance of itself.</returns>
    private static T CreateSingletonInstance<X>() where X : Component
    {
        GameObject gameObject = new GameObject(typeof(T).GetType().Name);
		gameObject.name = typeof(T).ToString();
//        Debug.LogWarning("Could not find " + gameObject.name + ", creating", gameObject);
        return gameObject.AddComponent<T>();
    }
	protected virtual void Update()
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			Awake();
		}
	}
 	protected virtual void Awake()
	{
		T[] allInstances = (GameObject.FindObjectsOfType(typeof(T)) as T[]);
		
		if (allInstances.Length > 1)
		{
//			for (int i = 0; i < allInstances.Length; i++)
//			{
//				if (allInstances[i] == this)
//				{
			if (Application.isPlaying)
			{
				GameObject.Destroy(this);
			}
			else if (Application.isEditor)
			{
				GameObject.DestroyImmediate(this);
			}
//				}
//			}
		}
	}
    /// <summary>
    /// Destroys the singleton. Important for cleaning up the static reference.
    /// </summary>
    public virtual void OnDestroy()
    {
        instance = null;
    }
}
