using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sens;
	public bool hideCursor;

	// Use this for initialization
	void Start () {
		if (hideCursor) {
			Cursor.visible = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float rotY = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sens;
		float rotX = transform.localEulerAngles.x - Input.GetAxis ("Mouse Y") * sens;
		gameObject.transform.localEulerAngles = new Vector3 (rotX, rotY, 0);
	}
}
