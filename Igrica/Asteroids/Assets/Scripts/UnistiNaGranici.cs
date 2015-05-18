using UnityEngine;
using System.Collections;

public class UnistiNaGranici : MonoBehaviour {
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
