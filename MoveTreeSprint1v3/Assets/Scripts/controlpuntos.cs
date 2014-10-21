using UnityEngine;
using System.Collections;

public class controlpuntos : MonoBehaviour {

	public fruta valormodificado1;
	public FrutaVerde valormodificado2;
	public FrutaDañada valormodificado3;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "normalidad");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void normalidad(){
		StartCoroutine (reajuste());
		}

	IEnumerator reajuste(){
		while (true) {
			yield return new WaitForSeconds(5);
			valormodificado1.valor = 3;
			valormodificado2.valor2 = 1;
			valormodificado3.valor3 = -1;
			yield break;
		}
	}		
}

