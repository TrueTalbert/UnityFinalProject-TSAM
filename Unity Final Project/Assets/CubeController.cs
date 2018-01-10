using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(0, 6, 6);
	}
	
	// Update is called once per frame
	void Update () {


	}
		
	void OnCollisionEnter(Collision collision)
	{
		
	}
}
