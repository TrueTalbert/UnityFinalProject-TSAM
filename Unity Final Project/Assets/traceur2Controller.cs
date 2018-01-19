using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traceur2Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel("level1");
		}
	}
}
