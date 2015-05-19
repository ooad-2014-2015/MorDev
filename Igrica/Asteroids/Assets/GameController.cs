using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] asteroidi;
	float time = 0.2f;
	float startTime = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (startTime > time) {
			Vector3 pozicija =new Vector3(Random.Range(-9, 9), 0.0f, 20.0f);
			GameObject asteroid = asteroidi[Random.Range(0, asteroidi.Length)];
			Quaternion rotacija = Quaternion.identity;

			Instantiate(asteroid,pozicija, rotacija);
			startTime = 0;
		}
		startTime += Time.deltaTime;
	}
}
