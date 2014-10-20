using UnityEngine;
using System.Collections;

public class FrutaVenenosa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){//Esta funcion se llama cuando el usuario ha presionado el collider del objeto.

		int veneno;

		veneno = Mathf.RoundToInt (Random.Range (1,2));

		NotificationCenter.DefaultCenter().PostNotification(this, "AccionarVeneno", veneno);//envia una notificacion
		// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
		DestroyObject (gameObject);//destruye el objeto.

	}
}
