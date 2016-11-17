using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public int speed = 5;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (-30, 0, 0) * Time.deltaTime * speed);  // Time.deltatime är den tiden som har förflutits sen vi började med spelet.
		//Transform är det publica fieldet i inspector för objektet som scriptet är lagt på.
	}
}
