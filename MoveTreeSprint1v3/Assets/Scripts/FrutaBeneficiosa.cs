using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TapGesture))]
[RequireComponent( typeof( FingerDownDetector ) )]
public class FrutaBeneficiosa : MonoBehaviour {

	public GameObject fingerDownObject;
	public int tiempoefecto=5; 
	public int efectofruta=5;
	private int eleccion;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnFingerDown( FingerDownEvent e )
	{
		//eleccion= Random.Range (1,2);
		eleccion = 2;
		if (eleccion == 1) {
						if (e.Selection == fingerDownObject) {
								efecto1 ();
								DestroyObject (gameObject);
						} else {
								Debug.Log ("no ha entradoal beneficio");
						}
		} else if (eleccion == 2) {
			if (e.Selection == fingerDownObject) {
				efecto2 ();
				DestroyObject (gameObject);
			} else {
				Debug.Log ("no ha entrado al beneficio");
			}

		}
	}

	void efecto1(){
		Debug.Log ("has llegado a este punto");
		NotificationCenter.DefaultCenter ().PostNotification (this, "realentizador",tiempoefecto);
	}

	void efecto2(){
//		Debug.Log ("has llegado a este punto 2");
//		NotificationCenter.DefaultCenter ().PostNotification (this, "efectofruta", efectofruta);

	}




}
