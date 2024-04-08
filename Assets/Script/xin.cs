using UnityEngine;
using System.Collections;

public class xin : MonoBehaviour {
	public Vector3 massofCenter;
	// Use this for initialization
	void Awake () {
		GetComponent<Rigidbody> ().centerOfMass = massofCenter; 
	
	}
	
	// Update is called once per frame

}
