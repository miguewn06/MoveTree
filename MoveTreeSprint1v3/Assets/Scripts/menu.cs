using UnityEngine;
using System.Collections;


public class menu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) { 
		if (gesture.Selection) {
			if(gesture.Selection.name == "Boton jugar"){
				Application.LoadLevel("Etapas");
			}
			else if(gesture.Selection.name == "Boton tienda"){
				Application.LoadLevel("Tienda");
			}
			else if(gesture.Selection.name == "Boton opciones"){
				Application.LoadLevel("Opciones");
			}
		}
	}

}
