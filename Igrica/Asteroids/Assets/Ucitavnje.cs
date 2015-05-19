using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Ucitavnje : MonoBehaviour {

	public string ucitano;
	public Text _text;
	void Start () {
	using (StreamReader sr = new StreamReader("Test.txt")) {
			ucitano = sr.ReadToEnd();
		}
		_text.text = ucitano;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
