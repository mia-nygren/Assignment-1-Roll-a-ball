using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	// Private Properties
	private int speed = 15;
	private int points; 
	private int numOfBananas = 0;
	private int numOfApples = 0;
	private HashSet<GameObject> bananas; 
	private HashSet<GameObject> apples;

	private Rigidbody rb; // Spelaren måste ha en rigid body.
	private SoundManager soundManager;  // This is used to play sounds
	private Fallout fallout; 
	private bool gameCompleted; 

	// Public Properties
	public Text pointText;
	public Text winText;
	public Text bananaText;
	public Text appleText;
	public AudioClip victory; 


	void Awake() {  // Awake will happen before Start
		if (soundManager == null) {
			soundManager = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		}
		if(bananas == null)
			bananas = GetAllFruitsWithTag ("Banana"); 
		if (apples == null)
			apples = GetAllFruitsWithTag ("Apple");
		
	}


	// Use this for initialization
	void Start () {		

		// I funktionen start kan vi börja med att ta reda på vart vår rigidBody finns.
		rb = GetComponent<Rigidbody>();
		gameCompleted = false;
		winText.text = "";
		points = 0;
		SetPointText ();
		if (GetComponent<Fallout> () != null) {
			fallout = GetComponent<Fallout> ();
		}

	}

	void FixedUpdate () // Denna körs automatiskt varje frame och hanterar fyskaliska saker
	{		 
		if (!fallout.getGameStatus() && !gameCompleted) { // if both are false the user can move
			// Här kan vi kolla efeter userinput 
			float moveHorizontal = Input.GetAxis ("Horizontal");  // Input.getAxis returnerar ett värde mellan -1 och 1 från tangentbord eller joystick eller touchplatta etc.
			float moveVertical = Input.GetAxis ("Vertical"); // z - since y is up in unity

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);  // Den tar helt enkelt reda på hur x och y axis är.
				rb.AddForce (movement * speed); // Rigidbody.addForce - ger kraft åt något 
		}
	}
		
	void OnTriggerEnter (Collider other) {
		GameObject gameObj = other.gameObject; 

		if (gameObj.tag == "Apple" | gameObj.tag == "Banana" | gameObj.tag == "BigBanana") {
			// Play the sound for the fruit
			soundManager.PlayFruitSound (gameObj);  
			gameObj.SetActive (false);    // Aktiverar eller avaktiverar ett gameObject.  Om vi träffar på det så vill vi sätta det till oaktivt.

			if (gameObj.tag == "Banana" | gameObj.tag == "BigBanana") { // Alla object i Unity kan ha något som kallas för en tag och detta kan vi använda för att hitta dem
				numOfBananas++;
				SetBananaText ();
				if (gameObj.tag == "BigBanana") {
				} else {
					// remove the banana from the HashSet
					bananas.Remove (gameObj);
				}
			}
				
			if (gameObj.tag == "Apple") {
				numOfApples++;
				SeApplesText ();
				// remove the apple from the HashSet
				apples.Remove (gameObj);
			}

			if (apples.Count <= 0 && numOfBananas == 12) {
				gameCompleted = true;
				// Play a victory sound
				soundManager.PlayClip(victory);
				fallout.resetPlayer(); // reset the position of the player
				winText.text = "Grattis Du vann! :D";
			}

			UpdatePoints (gameObj);
		}
	}
		
	// Private help methods

	private HashSet<GameObject> GetAllFruitsWithTag(string tag) {
		HashSet<GameObject> fruits = new HashSet<GameObject>();

		// Get all the fruits of type tag that are in the scene
		GameObject[] tmp = GameObject.FindGameObjectsWithTag (tag);

		foreach (GameObject fruit in tmp)
			fruits.Add (fruit);

		return fruits;  // Returns a HashSet of type Fruit containing the fruits that we just collected
	}

	private void UpdatePoints(GameObject other) {
		int num = getFruitPoint (other);
		points += num;	
		SetPointText ();
	}


	private void SetPointText(){		
		pointText.text = "Poäng: " + points.ToString();
	}

	private void SetBananaText() {
		bananaText.text = "Bananas: " + numOfBananas.ToString (); 
	}

	private void SeApplesText() {
		appleText.text = "Apples: " + numOfApples.ToString ();
	}
		

	private int getFruitPoint( GameObject gameObj) {
		Fruit fruit = gameObj.gameObject.GetComponent (typeof(Fruit)) as Fruit;  

		if (fruit != null) {
			return fruit.pointValue;
		}
		return 0;  // return 0 if not found.
 	}
		
}
