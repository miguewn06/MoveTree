using UnityEngine;
using System.Collections;

public class GenerarFruta : MonoBehaviour {

	//Referencia a los Prefab (Gameobjects) que se van a utilizar en este caso los prefabs de las frutas.
	public GameObject []obj;

	//Variables con los limites para el tiempo aleatorio en el cual aparecera la fruta
	public float tiempoMin = 0f;
	public float tiempoMax = 2f;

	//Variables para el movimiento (acelerometro)
	public float Tx;
	public float Ty;
	public float magnitud;
	public float magnitud1;
	private Vector2 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	private bool isShaking;
	private bool inicio = false;

	// Use this for initialization
	void Start () {
		Generar ();//modificacion para pruebas
		inicio = true;//modificacion para pruebas
	}

	// Update is called once per frame
	void Update () {
		Tx = Input.acceleration.x;
		Ty = Input.acceleration.y;
		
		//				
		//		if (Tx > 0.1 && Ty > 0.1) {
		//			Shake();
		//		}
		
		Vector2 vect = Vector2.zero;
		vect.x = Input.acceleration.x;
		vect.y = Input.acceleration.y;
		magnitud1 = vect.sqrMagnitude;
		if (vect.sqrMagnitude > 1.8 && !inicio) {
			magnitud = vect.sqrMagnitude;
			Generar ();
			inicio = true;
			//Shake();
		}
		if(!isShaking)
			
			return;
		
		if (shake_intensity > 0) {
			transform.position = originPosition + Random.insideUnitCircle * shake_intensity;
			//			transform.rotation = new Quaternion(
			//				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
			//				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
			//				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
			//				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else {
			Debug.Log("stopped shaking");
			isShaking = false;
			transform.position = originPosition;
			transform.rotation = originRotation;
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
						Application.Quit ();
				}

		if (Input.GetKey("escape")) {
			Debug.Log("Back Key pressed");
			Application.Quit ();
		}
		
	}
	
	void Generar (){
			NotificationCenter.DefaultCenter().PostNotification(this,"Iniciar",inicio);
		//Se instancia o llama los objetos que se generaran de manera aleatoria: las frutas madura, verde o dañada
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);

			//Se obtiene un numero aleatorio para generar una frecuencia diferente en que aparezca un fruto
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));

	}

	void Shake(){
		if(!isShaking){
			originPosition = transform.position;
			originRotation = transform.rotation;
		}
		isShaking = true;
		shake_intensity = .3f;
		shake_decay = 0.002f;
	}



}
