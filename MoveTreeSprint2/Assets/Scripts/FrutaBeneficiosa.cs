using UnityEngine;
using System.Collections;

public class FrutaBeneficiosa : MonoBehaviour {


	public GameObject efecto;
	public float valor = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		if (efecto.gameObject.tag == "Beneficiosa1") {//esta condicion marca el efecto de realentizar el tiempo.
			NotificationCenter.DefaultCenter().PostNotification(this, "contador", valor);
			DestroyObject(gameObject);
		}else if(efecto.gameObject.tag == "Beneficiosa2"){//esta condicion marca el efecto de aumentar el puntaje de los frutos.
			NotificationCenter.DefaultCenter().PostNotification(this,"incrementar");
			Destroy(gameObject);
		}
	}
}
