using UnityEngine;
using System.Collections;

public class NivelesNaranjas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) {
		
		if (gesture.Selection) {
			if (gesture.Selection.name == "Nivel1") {
				Application.LoadLevel ("Nivel1");
			}
			else if (gesture.Selection.name == "Nivel2") {
				Application.LoadLevel("Nivel2");
			}
		}
	}
}
