using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TapGesture))]
[RequireComponent( typeof( FingerDownDetector ) )]
public class fruta : MonoBehaviour {

	public GameObject fingerDownObject;


	public int valor= 3;//valor de una fruta madura.
	// Use this for initialization
	void Start () {

	}

	void OnFingerDown( FingerDownEvent e )
	{
		if (e.Selection == fingerDownObject) {
			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
			//			// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
			DestroyObject(gameObject);
				} else {
			Debug.Log("no ha entrado");
				}
	}

	void efectofruta(Notification n){
		Debug.Log ("cambio de valor");
		valor = (int)n.data;
	}



	// Update is called once per frame
	void Update () {

//		if(Input.touchCount == 1){
//
//			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//			Vector2 posiciontouch = new Vector2(wp.x, wp.y);
//			if(collider2D == Physics2D.OverlapPoint(posiciontouch)){
//				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
//				// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
//				DestroyObject(gameObject);
//			}
//		}


	}

//	void OnFingerDown(FingerDownEvent e){
//		Debug.Log (e.Finger + "Down at" + e.Position + "on object" + e.Selection.name);
//		DestroyObject (game);
//	}
//
//	void OnTap(TapGesture gesture) { 
//		if (gesture.Selection) {
//			Debug.Log ("Tapped object: " + gesture.Selection.name);
//			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
//			// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
//			DestroyObject(gameObject);
//		} else {
//			Debug.Log ("No object was tapped at " + gesture.Position);
//			
//		}
//	}

//	void OnMouseDown(){//Esta funcion se llama cuando el usuario ha presionado el collider del objeto.
//		NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor);//envia una notificacion
//		// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
//		DestroyObject (gameObject);//destruye el objeto.
//	}
}
