using UnityEngine;
using System.Collections;
using System.Text;

public class StringUTF8 {

	
	public static string Trans(string cadena) {
		
		Encoding iso = Encoding.GetEncoding("ISO-8859-1");
		Encoding utf8 = Encoding.UTF8;
		
		return utf8.GetString(iso.GetBytes(cadena));
	}	
}
