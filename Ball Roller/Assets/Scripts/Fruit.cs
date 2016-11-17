using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Fruit : MonoBehaviour {

	public string fruitName;
	public int pointValue;
	public AudioClip fruitSound;

	// To get a random volume range use floats
	private float volLowRange = 0.5f;
	private float volHighRange = 1.0f;

	public AudioClip getAudioClip(){ // the SoundManager uses this method
		return fruitSound;
	}
}
