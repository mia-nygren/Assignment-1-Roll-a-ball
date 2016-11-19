using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Fruit : MonoBehaviour {

	public string fruitName;
	public int pointValue;
	public AudioClip fruitSound;

	public AudioClip getAudioClip(){ // the SoundManager uses this method
		return fruitSound;
	}
}
