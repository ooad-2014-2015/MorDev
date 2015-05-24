using UnityEngine;
using System.Collections;

public class IntroAudioLogic : MonoBehaviour {
	// ne radi slider
	private static IntroAudioLogic instance = null;
	public static IntroAudioLogic Instance {
		get { return instance; }
	}

	public GameObject introAudio;
	void Start () {
	introAudio.GetComponent<AudioSource> ().Play ();
	}

	public void PostaviVolumen(float value)
	{
		Instance.GetComponent<AudioSource>().volume = value;
	}

    void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}

