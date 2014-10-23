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
	private bool inicio = true;

	private int tipoVeneno = 0;
	
	private Vector2 posAnteriorGenerador = new Vector2(0f,0f); // Vector 2D que guarda  la posicion del generador anterior
	public Vector2 posGenerador;
	public float dist;
	public float radio;
	//public float gravity;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (Generar (posAnteriorGenerador));
		NotificationCenter.DefaultCenter ().AddObserver (this,"AccionarVeneno");
		
		
	}
	
	// Update is called once per frame
	void Update () {
		NotificationCenter.DefaultCenter().PostNotification(this,"Iniciar",inicio);	// No se si este bn postear la notificacion cada frame, pero en Generar() no pasaba nada
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

			//StartCoroutine (Generar (posAnteriorGenerador));
			inicio = true;
			Shake();
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
	
	void AccionarVeneno (Notification veneno){  //notificacion que viene de la fruta venenosa que indica que se pulso
		tipoVeneno = (int)veneno.data;
	}
	
	IEnumerator Generar (Vector2 posGenAnt){ //funcion que se llama a traves de la Coroutine en Start()
		posAnteriorGenerador = posGenAnt;    //variable que guarda la posicion anterior de un generador
		while (inicio) {                     //necesario para que la generacion se repita (sin el solo se genera una fruta)
			
			//Vector2 distancia = new Vector2(5f, 5f);
			
			GameObject objIndividual;        
			//float dist;
			
			//------------- Genera la posicion aleatoria dentro de un circulo individual para cada punto generador (3 circulos)----------
			//Vector2 posInicGenerador;
			//posInicGenerador = this.transform.position;
			//Vector2 posGenerador = posInicGenerador + Random.insideUnitCircle * 2.5f; // Genera suna posicion aleatoria dentro de un circulo de radio 2.5
			//----------------------------------------------------------------------------------------------------------------------------------
			
			posGenerador = Random.insideUnitCircle * 3f; //posGenerador cuarda un vector 2D que representaea la posicion aleatoria de un punto generador
			
			//-----------otra forma de hallar la distancia: restando los dos vectores de posicion-----------
			//Vector2 resta = posGenerador - posAnteriorGenerador;
			//(resta.sqrMagnitude > distancia.sqrMagnitude.............dentro del condicional
			//--------------------------------------------------------------------------------------
			
			//----------para sacar la hipotenusa (si los vectores forman un triangulo) que seria la distancia-----------
			//float hyp, hyp2;
			//hyp2 = Mathf.Pow (posGenerador.magnitude,2) + Mathf.Pow(posAnteriorGenerador.magnitude,2); 
			//hyp = Mathf.Sqrt (hyp2);
			//----------------------------------------------------------------------------------------
			
			objIndividual = obj [Random.Range (0, obj.Length)]; //trae un objeto (fruta) dentro de los prefabs
			
			//--------- Condicion que acciona el VENENO, fija una velocidad de las frutas durante 5 segundos--------
			if(tipoVeneno == 1){
				objIndividual.rigidbody2D.gravityScale = 3;        //aumenta la velocidad si hay veneno
				Invoke ("contador", 5);
				
			}else if (tipoVeneno == 0){
				objIndividual.rigidbody2D.gravityScale = 1;        //vuelve a la veloc normal si no hay veneno
				
			}
			else if(tipoVeneno ==2){

				objIndividual = obj[2];
				Invoke ("contador", 5);
			}
			//------------------------------------------------------------------------------------------
			
			
			dist = Vector2.Distance (posGenerador, posAnteriorGenerador);   //calcula la distancia entre dos puntos: la posicion actual y la anterior 
			//(no se como se halla la distancia, LAS POSICIONES SON PTOS O VECTORES? esta bn hallada la dist?)
			//size = objIndividual.renderer.bounds.size.magnitude;         //debo utilizar el radio o el tamano (no se que es el tamano)
			
			radio = objIndividual.GetComponent<CircleCollider2D> ().radius; //se halla el radio del collider del objeto (fruta) actual
			
			if (posGenerador.y > 0.8 && dist > 2 * radio) {  //el primer valor es para que las frutas aparezcan arriba de un limite
				//el segundo valor compara la distancia y el diametro. Si la distancia entre las posiciones es mayor al diametro de la fruta, no deberian traslaparse las dos frutas
				
				//Se instancia o llama los objetos que se generaran de manera aleatoria: las frutas madura, verde o dañada
				Instantiate (objIndividual, posGenerador, Quaternion.identity);
				posAnteriorGenerador = posGenerador;        //se guarda la posicion del actual como la posicion del anterior para pasarlo de nuevo a Generar()
				
				//Se instancia o llama los objetos que se generaran de manera aleatoria: las frutas madura, verde o dañada
				//Instantiate (obj [Random.Range (0, obj.Length)], posGenerador, Quaternion.identity);
				
				//Se obtiene un numero aleatorio para generar una frecuencia diferente en que aparezca un fruto
				//Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
				
				//en conjunto con la Courutine, hace q haya un retardo del tiempo que se le ponga como parametro
				yield return new  WaitForSeconds (Random.Range (tiempoMin, tiempoMax));
				Generar (posAnteriorGenerador);     //se llama a la funcion de nuevo y se le envia la posic del anterior
			} else {
				Generar (posAnteriorGenerador);		//se llama de nuevo a la funcion si no cumple el if
			}
		}
		
	}
	
	void contador(){ // se llama mediante invoke despues de 5 segundos para cambiar la variable tipoVeneno y asi se acabe el efecto
		tipoVeneno = 0;
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
