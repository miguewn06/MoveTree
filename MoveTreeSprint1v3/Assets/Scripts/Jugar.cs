﻿using UnityEngine;
using System.Collections;


public class Jugar : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnMouseDown(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "JuegoTerminado",2);
		Application.LoadLevel ("Nivel1");

	}
}
