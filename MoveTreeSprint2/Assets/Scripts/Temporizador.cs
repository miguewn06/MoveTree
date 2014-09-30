// Este codigo genera el temporizador del juego el cual dura 30 segundos.

using UnityEngine;
using System.Collections;

public class Temporizador : MonoBehaviour {

	public TextMesh tiempo;//toma el campo TextMesh del objeto Puntuacion en unity. 
	public float tiempomaximo= 10f;//valor de duracion del temporizador.
	public int t=10;//valor entero de referencia. Solamente interesa que sea distinto de cero.
	public bool inicio = false;



	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"Iniciar");

	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Iniciar (Notification inicio1){
		inicio = (bool)inicio1.data;

	}

	void FixedUpdate (){//esta funcion se actualiza una vez por segundo.
		if(inicio){
		contador ();//llamada a contador.
		}
	}

	void contador(){

		if (t != 0) {//condicional para que el conteo termine al llegar a cero.
						tiempomaximo = tiempomaximo - Time.deltaTime;// Time.deltaTime es un valor float que calcula el tiempo que pasa desde la ultima
						//actualizacion de un frame.En este caso sera una vez por segundo debido al FixedUpdate.
						t = Mathf.RoundToInt (tiempomaximo);//t es el entero de tiempomaximo.
						tiempo.text = t.ToString ();//se actualiza el valor text del campo TextMesh en unity.
		} else if (t == 0) {
			GameObject[] terminar1 = GameObject.FindGameObjectsWithTag("Generador");
			foreach (GameObject obj in terminar1){
				UnityEngine.Object.Destroy(obj);
			}
		}

	}
}
