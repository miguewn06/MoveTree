using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TapGesture))]
[RequireComponent( typeof( FingerDownDetector ) )]
public class FrutaVenenosa : MonoBehaviour {

	public GameObject fingerDownObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnFingerDown( FingerDownEvent e )
	{
		if (e.Selection == fingerDownObject) {

		int veneno;

		veneno = Mathf.RoundToInt (Random.Range (1,2));

		NotificationCenter.DefaultCenter().PostNotification(this, "AccionarVeneno", veneno);//envia una notificacion
		// llamando a "IncrementarPuntaje" y con el valor de la fruta madura.
		DestroyObject (gameObject);//destruye el objeto.

	}
	}
}
