using UnityEngine;
using System.Collections;

[System.Serializable]
public class Granica
{
	public float xMin, xMax, zMin, zMax;
}

public class Moving : MonoBehaviour {
	public float speed = 10;
	public Granica granica;
	public float tilt;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, granica.xMin, granica.xMax),
				0.0f,
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, granica.zMin, granica.zMax)
				);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
