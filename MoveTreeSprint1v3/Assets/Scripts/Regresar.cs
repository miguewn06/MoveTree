using UnityEngine;
using System.Collections;

public class Regresar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) {

		if (gesture.Selection) {
			if(gesture.Selection.name == "Volver"){
				Application.LoadLevel("Menu");
			}
			else if(gesture.Selection.name == "Volver etapa"){
				Application.LoadLevel("Etapas");
			}
			else if(gesture.Selection.name == "Volver niveles"){
				Application.LoadLevel("Niveles etapa1");
			}
		}
	}
}
