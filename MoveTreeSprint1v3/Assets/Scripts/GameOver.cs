using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject camaraGameObject;
	public Puntuacion puntos;
	public TextMesh totalpuntos;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "JuegoTerminado");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void JuegoTerminado(){
		camaraGameObject.SetActive (true);
		totalpuntos.text = puntos.puntaje.ToString ();
	}


}
