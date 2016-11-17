using UnityEngine;
using System.Collections;

public class Fallout : MonoBehaviour {

	private int lives = 2;
	private SoundManager soundManager;
	private bool collision = false;
	public Transform respawn;
	private Rigidbody rb;

	void Awake() {  // Awake will happen before Start
		if (!soundManager) {
			soundManager = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		}
	}

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (collision) {   // only true if it did collide with the barrier
			if (transform.position.y < -100f) {
				// reset the force    
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
				transform.position = respawn.position;  // reset the player position to the respawn 
				collision = false;  // reset barrier
			}
		}

	}

	void OnTriggerEnter( Collider other) {
		if (other.tag == "Barrier") { 
			collision = true;
			soundManager.PlayClip (other.GetComponent<AudioSource> ().clip);
			lives -= 1;
			if(lives <= 0) 
				Debug.Log ("GAME OVER");
			
		}
	}

}