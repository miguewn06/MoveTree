using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public TextMesh Puntaje;//toma el campo TextMesh del objeto Puntuacion en unity.
	int puntaje= 0;//valor inicial del puntaje


	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver (this, "IncrementarPuntaje");//cada vez que alguien envie una notificacion 
		//con el nombre "IncrementarPuntaje", entonces se llama a la funcion descrita abajo.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IncrementarPuntaje(Notification notification){//funcion que se activa al ser notificada por alguien.
		int incrementarpuntos = (int)notification.data;//valor a incrementar dado por el notificador.
		if (puntaje == 0 && incrementarpuntos == -1) {
			puntaje = 0;
			Puntaje.text = puntaje.ToString ();//modifica el valor text del textMesh del objeto.
		} else {
				puntaje = puntaje + incrementarpuntos;//puntaje total
				Puntaje.text = puntaje.ToString ();//modifica el valor text del textMesh del objeto.
		}
	}
}
