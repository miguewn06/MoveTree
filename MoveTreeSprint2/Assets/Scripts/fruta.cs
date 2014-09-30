using UnityEngine;
using System.Collections;

public class fruta : MonoBehaviour {

	private bool mover = false; 
	public int valor= 3;//valor de una fruta madura.
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1){

			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 posiciontouch = new Vector2(wp.x, wp.y);
			if(collider2D == Physics2D.OverlapPoint(posiciontouch)){
				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
				// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
				DestroyObject(gameObject);
			}
		}


	}

//	void OnMouseDown(){//Esta funcion se llama cuando el usuario ha presionado el collider del objeto.
//		NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
//		// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
//		DestroyObject (gameObject);//destruye el objeto.
//	}
}
