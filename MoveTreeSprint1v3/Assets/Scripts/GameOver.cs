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

	void JuegoTerminado(Notification n){
		int control = (int)n.data;
		if(control==1){
			camaraGameObject.SetActive (true);
			totalpuntos.text = puntos.puntaje.ToString ();
		}
		else if(control==2){
			camaraGameObject.SetActive(false);
		}

	}


}
