using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeController : MonoBehaviour {
	public Rigidbody rb;
	public RigidbodyConstraints constraints;
	public bool rightside;
	public bool onwall;
	public bool dead;
	public bool jump;
	public float levelnumber;
	public Text respawn;
	public float countdown;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(8, 6, 6);
		rightside = true;
		dead = false;
		respawn.enabled = false;

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
			jump = true;
			//transform.Rotate (0, 180, 0);
		}
		if (Input.GetKeyDown ("r")){
			Application.LoadLevel(Application.loadedLevel);
		}
		if (!onwall) {
			countdown += 1;
		}
		if (!onwall && (countdown > 240)) {
			respawn.enabled = true;
		}
		Vector3 vel = rb.velocity;
		vel.x = 8;
		rb.velocity = vel;
	}
		
	void OnCollisionEnter(Collision collision)
	{
		if (!dead && collision.gameObject.tag == "Wall") {
			rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			Physics.gravity = new Vector3 (0, -4f, 0);
			rb.velocity = new Vector3 (0, 0, 0);
			onwall = true;
			jump = false;
			countdown = 0;
			respawn.enabled = false;
		}
		if (collision.gameObject.tag == "Edgy") {
			Physics.gravity = new Vector3(0, -9.8f, 0);
			rb.constraints = RigidbodyConstraints.None;
			dead = true;
			respawn.enabled = true;

		}
		if (collision.gameObject.tag == "End") {
			Application.LoadLevel("level" + levelnumber.ToString());
		}
	}
	void OnCollisionExit(Collision collision)
	{
		if (!jump) {
			onwall = false;
			Physics.gravity = new Vector3(0, -9.8f, 0);
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
	}
		
}