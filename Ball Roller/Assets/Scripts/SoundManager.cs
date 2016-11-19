using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	private AudioSource source;
	private AudioClip clip;
	private Fruit fruit; 

	// Use this for initialization
	void Start () {
		if (source == null) {			
			source = gameObject.AddComponent<AudioSource> (); 
			//Debug.Log ("Started SoundManager" + gameObject.name );
		}
	}

	public void PlayFruitSound(GameObject obj) {
		fruit = obj.GetComponent<Fruit> ();
		clip = fruit.getAudioClip ();
		if (source != null && clip != null) {
			source.PlayOneShot (clip); 

		}
	}

	public void PlayClip(AudioClip clip) {
		if (source != null && clip != null) {
			source.PlayOneShot (clip); 
		}
	}
}
