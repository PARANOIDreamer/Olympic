using UnityEngine;
using System.Collections;

public class zhongxin : MonoBehaviour {

	public Transform tf;

	void Update () {

		GetComponent<Rigidbody> ().centerOfMass = tf.localPosition;

	}
}
