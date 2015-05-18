using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour {
	public float speed = -5;
	void Start()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
}
