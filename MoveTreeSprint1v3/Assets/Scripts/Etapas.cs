using UnityEngine;
using System.Collections;

public class Etapas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) {
		
		if (gesture.Selection) {
			if(gesture.Selection.name == "etapa 1"){
				Application.LoadLevel("Niveles etapa1");
			}
		}
	}
}
