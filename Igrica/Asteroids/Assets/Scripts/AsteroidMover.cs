using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour {
	public float speed = -5;
	void Start()
	{
		Vector3 brzina = new Vector3 (-1, 0, -0.5f) * 5;
		GetComponent<Rigidbody> ().velocity = brzina;

	}
}
