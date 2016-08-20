using UnityEngine;
using System.Collections;

public class Colorizer : MonoBehaviour {

	// Use this for initialization
	public Color diffuseColor;
	
	// Update is called once per frame
	void Update () {
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", diffuseColor);
	}
}
