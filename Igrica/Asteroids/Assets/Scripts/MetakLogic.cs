using UnityEngine;
using System.Collections;

public class MetakLogic : MonoBehaviour {
	public float brzina = 15;
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 1) * brzina;
	}
}
