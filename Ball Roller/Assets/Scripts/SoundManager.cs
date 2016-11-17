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
			Debug.Log ("STARTED SoundManager" + gameObject.name );
		}
	}

	public void PlayFruitSound(GameObject obj) {
		Debug.Log ("SHOULDPLAYSOUND from soundmanager:  " + obj.name);
		fruit = obj.GetComponent<Fruit> ();
		clip = fruit.getAudioClip ();
		Debug.Log ("clip is " + clip.name);
		if (source != null && clip != null) {
			source.PlayOneShot (clip); 

		}
	}

	public void PlayClip(AudioClip clip) {
		Debug.Log ("clip GAMOVE " + clip.name);
		if (source != null && clip != null) {
			source.PlayOneShot (clip); 
		}
	}
}
