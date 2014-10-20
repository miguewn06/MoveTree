using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TapGesture))]
[RequireComponent( typeof( FingerDownDetector ) )]
public class FrutaVerde : MonoBehaviour {

	public GameObject fingerDownObject;
	public int valor2= 1;//valor de una fruta verde.
	// Use this for initialization
	void Start () {
		
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
//			}
//		}
	}
	void OnFingerDown( FingerDownEvent e )
	{
		if (e.Selection == fingerDownObject) {
			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor2);//envia una notificacion
			//			// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
			DestroyObject(gameObject);
		} else {
			Debug.Log("no ha entrado");
		}
	}
//	void OnTap(TapGesture gesture) { 
//		if (gesture.Selection) {
//			Debug.Log ("Tapped object: " + gesture.Selection.name);
//			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor2);//envia una notificacion
//			// llamando a "IncrementarPuntaje" y con el valor de la fruta verde.
//			DestroyObject(gameObject);
//		} else {
//			Debug.Log ("No object was tapped at " + gesture.Position);
//			
//		}
//	}
//	void OnMouseDown(){//Esta funcion se llama cuando el usuario ha presionado el collider del objeto.
//		
//		NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntaje", valor2);//envia una notificacion
//		// llamando a "IncrementarPuntaje" y con el valor de la fruta verde.
//		DestroyObject (gameObject);//destruye el objeto.
//	}
}
