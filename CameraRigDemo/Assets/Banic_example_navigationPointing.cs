using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Banic_example_navigationPointing: MonoBehaviour {

	
	public float currentTime;
	public float timeToDrop;



	// Use this for initialization
	void Start () {
		timeToDrop = 2f;
	}

	// Update is called once per frame
	void Update () {
		
		RaycastHit raycastHit = new RaycastHit (); // create new raycast hit info object
		transform.Translate (Camera.main.ScreenPointToRay(Input.mousePosition).direction * Time.deltaTime); 


		//wayfinding
		/*
		if (currentTime > timeToDrop) {

			GameObject breadcrumb = GameObject.CreatePrimitive (PrimitiveType.Cube);
			breadcrumb.AddComponent<Rigidbody> ();
			breadcrumb.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			breadcrumb.transform.position = transform.position;
			currentTime = 0.0f;
		}
		currentTime += Time.deltaTime;
		print (currentTime);
             */
       
	}



}
