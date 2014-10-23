using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(TapGesture))]
//[RequireComponent( typeof( FingerUpDetector ) )]

public class HerramientaCuidado : MonoBehaviour {

	//public GameObject fingerUpObject;

	public GameObject herramientaCuidado;

	public int cantidadHerrAgua = 0;
	public int cantidadHerrAbono = 0;
	public int cantidadHerrPesticida = 0;

	//public Vector3 posInicial = new Vector3 (-0.02240026f, -3.961265f, -0.9315548f) ; rrrrrrrrrrrrrrrrevisar

	// Use this for initialization
	void Start () {
	
	}

//	void OnMouseUpAsButton(){
//		herramientaCuidado.transform.position = posInicial;
//	}

    int dragFingerIndex = -1;

    void OnDrag(DragGesture gesture)
    {
        // first finger
        FingerGestures.Finger finger = gesture.Fingers[0];

		//posInicial = herramientaCuidado.transform.position;   rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrevisar

        if (gesture.Phase == ContinuousGesturePhase.Started)
        {
            // dismiss this event if we're not interacting with our drag object
			if (gesture.Selection != herramientaCuidado)
                return;

            //UI.StatusText = "Started dragging with finger " + finger;

            // remember which finger is dragging dragObject
            dragFingerIndex = finger.Index;

            // spawn some particles because it's cool.
            //SpawnParticles( dragObject );
        }
        else if (finger.Index == dragFingerIndex)  // gesture in progress, make sure that this event comes from the finger that is dragging our dragObject
        {
            if (gesture.Phase == ContinuousGesturePhase.Updated)
            {
                // update the position by converting the current screen position of the finger to a world position on the Z = 0 plane
				herramientaCuidado.transform.position = GetWorldPos(gesture.Position);


            }
            else
            {

                // reset our drag finger index
                dragFingerIndex = -1;
				//herramientaCuidado.transform.position = posInicial;  rrrrrrrrrrrrrrrrrrrrrevisar

                // spawn some particles because it's cool.
                //SpawnParticles(dragObject);

            }
        }
    }

//	void OnFingerUp(FingerUpEvent e ){
//
//		if (e.Selection == fingerUpObject) {
//		
//			herramientaCuidado.transform.position = posInicial;
//		}
//		}


	// Update is called once per frame
	void Update () {
	
		NotificationCenter.DefaultCenter ().AddObserver (this,"disminuirCantidadHerramientas");
	}

	void disminuirCantidadHerramientas (Notification decremento){  

		if (decremento.data == "HerrPesticida") {

			cantidadHerrPesticida -= 1; 
		} else if (decremento.data == "HerrAbono"){

			cantidadHerrAbono -= 1; 
		}else{

			cantidadHerrAgua -= 1; 
		}

	}

	Vector3 GetWorldPos( Vector2 screenPos )
	{
			Camera mainCamera = Camera.main;
			return mainCamera.ScreenToWorldPoint( new Vector3( screenPos.x, screenPos.y, Mathf.Abs( transform.position.z - mainCamera.transform.position.z ) ) );
	}
}
