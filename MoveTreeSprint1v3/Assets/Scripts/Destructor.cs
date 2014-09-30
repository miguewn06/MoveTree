using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){//Esta funcion detecta colision con objetos que tengan el trigger activo en unity
		DestroyObject (other.gameObject);// destruye los objetos trigger que colisionen con el objeto.
	}
}
