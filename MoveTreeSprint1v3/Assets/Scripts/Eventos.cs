using UnityEngine;
using System.Collections;

public class Eventos : MonoBehaviour {

	public int eventoHelada = 1;
	public int eventoCalor = 2;
	public int eventoLluvia = 3;
	public int eventoPlaga = 4;

	public string escenaActual;
	public int eventoEscena;

	// Use this for initialization
	void Start () {
	
		escenaActual = Application.loadedLevelName;
		definirEvento ();

	}
	
	// Update is called once per frame
	void Update () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "accionarEvento");
	}

	void definirEvento(){

		if (escenaActual == "Nivel5") {
			eventoEscena = Random.Range (1,4);

		}else if (escenaActual == "Nivel6") {
			eventoEscena = Random.Range (1,4);

		}else if (escenaActual == "Nivel7") {
			eventoEscena = Random.Range (1,4);

		}else if (escenaActual == "Nivel8") {
			eventoEscena = Random.Range (1,4);

		}

	}

	void accionarEvento (Notification n){
		bool accionEvento = (bool)n.data;
		if (accionEvento){
			Invoke("cambiarFondo",10);
			Sprite fondo = Resources.LoadAssetAtPath("Assets/Sprites/Arbol Naranjo.jpg", typeof(Sprite)) as Sprite;
			GetComponent<SpriteRenderer>().sprite = fondo;


		}
	}

	void cambiarFondo(){
		Sprite fondo = Resources.LoadAssetAtPath("Assets/Sprites/Arbol_naranja_niveles.jpg", typeof(Sprite)) as Sprite;
		GetComponent<SpriteRenderer>().sprite = fondo;
	}
}
