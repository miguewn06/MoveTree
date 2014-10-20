using UnityEngine;
using System.Collections;

public class Jugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log ("jajajajaj");
		Application.LoadLevel ("Nivel1");
	}
}
