// Este codigo genera el temporizador del juego el cual dura 30 segundos.

using UnityEngine;
using System.Collections;

public class Temporizador : MonoBehaviour {

	public TextMesh tiempo;//toma el campo TextMesh del objeto Puntuacion en unity.
	public TextMesh tiempo2;
	public float tiempomaximo= 10f;//valor de duracion del temporizador.
	public int t=10;//valor entero de referencia. Solamente interesa que sea distinto de cero.
	public int a;
	public bool inicio = false;
	public GameObject cambio;
	public GameObject cambio2;



	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this,"Iniciar");
		NotificationCenter.DefaultCenter ().AddObserver (this,"contador");

	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Iniciar (Notification inicio1){
		inicio = (bool)inicio1.data;

	}

	void FixedUpdate (){//esta funcion se actualiza una vez por segundo.
		if(inicio){
		contador (null);//llamada a contador.
		}
	}

	void contador(Notification notificacion){
				if (notificacion != null) {
						float e1 = (float)notificacion.data;
			cambio2.SetActive(true);
			cambio.SetActive(false);
			tiempo2.text= t.ToString();
			//Debug.Log(tiempo2.text);
						if (t != 0) {//condicional para que el conteo termine al llegar a cero.
								tiempomaximo = tiempomaximo - (Time.deltaTime - e1);// Time.deltaTime es un valor float que calcula el tiempo que pasa desde la ultima
								//actualizacion de un frame.En este caso sera una vez por segundo debido al FixedUpdate.
								t = Mathf.RoundToInt (tiempomaximo);//t es el entero de tiempomaximo.
								tiempo.text = t.ToString ();//se actualiza el valor text del campo TextMesh en unity.
				//Debug.Log(tiempo.text);


						} else if (t == 0) {
								GameObject[] terminar1 = GameObject.FindGameObjectsWithTag ("Generador");
								foreach (GameObject obj in terminar1) {
										UnityEngine.Object.Destroy (obj);
								}
						}
		}else if(notificacion == null){
			if (t != 0) {//condicional para que el conteo termine al llegar a cero.
				a = int.Parse(tiempo2.text);
				Debug.Log(a);
				Debug.Log(tiempo.text);
				//Debug.Log(tiempo2.text);
				tiempomaximo = tiempomaximo - Time.deltaTime;// Time.deltaTime es un valor float que calcula el tiempo que pasa desde la ultima
				//actualizacion de un frame.En este caso sera una vez por segundo debido al FixedUpdate.
				t = Mathf.RoundToInt (tiempomaximo);//t es el entero de tiempomaximo.
				tiempo.text = t.ToString ();//se actualiza el valor text del campo TextMesh en unity.
			} else if (t == 0) {
				GameObject[] terminar1 = GameObject.FindGameObjectsWithTag ("Generador");
				foreach (GameObject obj in terminar1) {
					UnityEngine.Object.Destroy (obj);
				}
			}
		}			
	}
}
