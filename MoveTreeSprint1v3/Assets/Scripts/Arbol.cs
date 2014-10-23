using UnityEngine;
using System.Collections;

public class Arbol : MonoBehaviour {

    public int maxHealth = 100;
    public int curHealth = 10;

    public Texture2D bgImage;
    public Texture2D fgImage;

    public float healthBarLength;

	public string herrDecrementada = "";

	public int c;
    

	// Use this for initialization
	void Start () {

        healthBarLength = Screen.width / 2; 
	}
	
	// Update is called once per frame
	void Update () {

        AddjustCurrentHealth(0);
	}


	void OnTriggerEnter2D (Collider2D herramientaCuidado){
		 

		if (herramientaCuidado.tag == "HerrPesticida") {

			AddjustCurrentHealth (20);
			herrDecrementada = "HerrPesticida";
			herramientaCuidado.transform.position = new Vector3 (-0.02240026f, -3.961265f, -0.9315548f);
		} else if (herramientaCuidado.tag == "HerrAbono"){

			AddjustCurrentHealth (10);
			herrDecrementada = "HerrAbono";
			herramientaCuidado.transform.position = new Vector3 (-2.611698f, -3.961265f, -0.9315548f);
		}else if (herramientaCuidado.tag == "HerrAgua"){

			AddjustCurrentHealth (5);
			herrDecrementada = "HerrAgua";
			herramientaCuidado.transform.position = new Vector3 (2.528783f, -3.961265f, -0.9315548f);
		}

		NotificationCenter.DefaultCenter().PostNotification(this,"disminuirCantidadHerramientas",herrDecrementada);
		herrDecrementada = "";
	}

    void OnGUI()
    {
        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(0, 0, healthBarLength, 32));

        // Draw the background image
        GUI.Box(new Rect(0, 0, healthBarLength, 32), bgImage);

        // Create a second Group which will be clipped
        // We want to clip the image and not scale it, which is why we need the second Group
        GUI.BeginGroup(new Rect(0, 0, curHealth / maxHealth * healthBarLength, 32));

        // Draw the foreground image
        GUI.Box(new Rect(0, 0, healthBarLength, 32), fgImage);

        // End both Groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentHealth(int adj)
    {

        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }


}
