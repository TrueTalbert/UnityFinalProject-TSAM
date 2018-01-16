using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	public Rigidbody rb;
	public RigidbodyConstraints constraints;
	public bool rightside;
	public bool onwall;
	public bool dead;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(12, 6, 6);
		rightside = true;
		dead = false;
	}

	void FixedUpdate () {
		if (!dead && Input.GetKeyDown ("space") && onwall) {
			Physics.gravity = new Vector3(0, -9.8f, 0);
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			if (rightside){
				rb.velocity = new Vector3 (0, 6, -6);
				rightside = false;
			} else {
				rb.velocity = new Vector3 (0, 6, 6);
				rightside = true;
			}
			onwall = false;
			//transform.Rotate (0, 180, 0);
		}
		Vector3 vel = rb.velocity;
		vel.x = 6;
		rb.velocity = vel;
	}
		
	void OnCollisionEnter(Collision collision)
	{
		if (!dead && collision.gameObject.tag == "Wall") {
			rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			Physics.gravity = new Vector3 (0, -4f, 0);
			rb.velocity = new Vector3 (0, 0, 0);
			onwall = true;
		}
		if (collision.gameObject.tag == "Edgy") {
			Physics.gravity = new Vector3(0, -9.8f, 0);
			rb.constraints = RigidbodyConstraints.None;
			dead = true;

		}
	}
		
}