using UnityEngine;
using System.Collections;

public class FrutaVerde : MonoBehaviour {

	public int valor2= 1;//valor de una fruta verde.
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "incrementar");
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.touchCount == 1){
//			
//			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//			Vector2 posiciontouch = new Vector2(wp.x, wp.y);
//			if(collider2D == Physics2D.OverlapPoint(posiciontouch)){
//				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor2);//envia una notificacion
//				// llamando a "IncrementarPuntaje" y con el valor de la fruta verde.
//				DestroyObject(gameObject);
			}
	//	}
//	}
	
	void incrementar(){//Esta funcion se llama cuando el usuario ha presionado el collider del objeto.
	for(int i=0; i<60; i++){
		for(int b=0; b<18.9;b++){
			valor2 = 3;
		
		// llamando a "IncrementarPuntaje" y con el valor de la fruta verde.
		DestroyObject (gameObject);//destruye el objeto.
			}
		}NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor2);//envia una notificacion
	}
}
