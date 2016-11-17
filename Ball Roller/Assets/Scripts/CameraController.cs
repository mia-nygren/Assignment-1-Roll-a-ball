using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player; // Här kommer vi åt spelaren - bollen
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		// offset mellan kameran och spelaren 
		offset = transform.position;  // Vilken position befinners sig min spelare i för tillfället
	
	}
	
	void LateUpdate() {
		// En av unitys inbygda funktioner
		// Anropas efter FixedUpdate - som hanterar fysikaliska saker -  har anropats
		// Update() hanterar allt som ska förändras per frame

		// Här vill vi ta reda på / Sätta kamerans position
		transform.position = player.transform.position + offset;

	}
}
