using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BarraHealthStatus : MonoBehaviour {

[SerializeField] private Slider slider;
    private Health vida;
    private float valorVida;
	// Use this for initialization
	void Start () {
        
       slider.enabled = false;
       
        
	}
	
	// Update is called once per frame
	void Update () {
        

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            slider.enabled = true;
            // vida = PhotonView.Get(GetComponent<Health>());
            //vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().currentHitPoints;
            //slider.value = vida/100;
            Debug.Log(slider.value);
        }

	}
}
