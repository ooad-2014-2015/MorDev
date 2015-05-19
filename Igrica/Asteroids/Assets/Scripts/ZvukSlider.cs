using UnityEngine;
using System.Collections;

public class ZvukSlider : MonoBehaviour {

	// Problem sto 2 puta pali istu muziku kad se vratim u intro scenu
	public GameObject introAudio;

	void Start () {
		introAudio.GetComponent<AudioSource> ().Play ();
	}

	public void PostaviVolumen(float value)
	{
		introAudio.GetComponent<AudioSource>().volume = value;
	}

    void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}

