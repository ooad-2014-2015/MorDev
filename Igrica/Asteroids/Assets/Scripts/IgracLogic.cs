using UnityEngine;
using System.Collections;

public class IgracLogic : MonoBehaviour, IObserver {

	private float tilt = 5;
	private float xMin = -17.0f, xMax = 17.0f, zMin = 1.0f, zMax = 18.5f;

	public GameObject metak;
	public Transform metakLokacija;


	public float fireRate = 0.5f;
	public float speed = 5;

	float nextFire = 0.0f;

	public void update (int brojBodova)
	{
		if (brojBodova >= 50) {
			if (brojBodova <= 100) {
				speed = 6;
				fireRate = 0.4f;
			} else if (brojBodova <= 300) {
				speed = 7;
				fireRate = 0.3f;
			} else if (brojBodova <= 500) {
				speed = 8;
				fireRate = 0.3f;
			} else if (brojBodova <= 1000) {
				speed = 9;
				fireRate = 0.3f;
			} else {
				speed = 10;
				fireRate = 0.2f;
			}
		}
	}
	void Update()
	
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			pucaj();
		}
	}

	public void pucaj() {
		Instantiate (metak, metakLokacija.position, metakLokacija.rotation);
		GetComponent<AudioSource>().Play();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
				0.0f,
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax)
				);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

 
}
