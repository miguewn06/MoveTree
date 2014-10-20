using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public int tiempoSplash = 5;
	// Use this for initialization
	void Start () {
		StartCoroutine (cargar());
	}

	IEnumerator cargar(){

		yield return new WaitForSeconds (tiempoSplash);
		Application.LoadLevel ("Menu");
	}

}
