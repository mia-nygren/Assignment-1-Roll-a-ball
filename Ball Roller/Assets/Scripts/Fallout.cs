using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fallout : MonoBehaviour {

	private int lives = 2;
	private SoundManager soundManager;
	private bool collision = false;
	public Transform respawn;
	private Rigidbody rb;
	public Text gameOverText; 
	public Text numOfLives; 
	private bool gameOver;

	void Awake() {  // Awake will happen before Start
		if (!soundManager) {
			soundManager = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		}
		gameOverText.text = "";
		numOfLives.text = "Lives: " + lives.ToString ();
		gameOver = false;
	}

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (collision) {   // only true if it did collide with the barrier
			if (transform.position.y < -100f) {
				resetPlayer(); // reset the player position to the respawn 
				collision = false;  // reset barrier
			}
		}
	}

	void OnTriggerEnter( Collider other) {
		if (other.tag == "Barrier") { 
			collision = true;
			soundManager.PlayClip (other.GetComponent<AudioSource> ().clip);
			lives -= 1;
			numOfLives.text = "Lives: " + lives.ToString (); 
			if (lives <= 0) {
				gameOverText.text = "Game Over!!! :(";
				gameOver = true;
			}
			
		}
	}

	public bool getGameStatus() {
		return gameOver; 
	}

	public void resetPlayer() {
		// reset the force    
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.position = respawn.position;  // reset the player position to the respawn 
	}

}