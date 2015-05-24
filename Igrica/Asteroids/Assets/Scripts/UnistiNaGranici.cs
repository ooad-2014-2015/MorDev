using UnityEngine;
using System.Collections;

public class UnistiNaGranici : MonoBehaviour {
	private GameObject controller;
	private GameController _gc;

	public void Start()
	{
		controller = GameObject.FindWithTag("GC");
		_gc = controller.GetComponent<GameController> ();
	}

	void OnTriggerExit(Collider other)
	{
		if (!_gc.mrtav) {
			if (other.tag == "Asteroid1")
				_gc.brojBodova += 1;
			else if (other.tag == "Asteroid2")
				_gc.brojBodova += 2;
			else if (other.tag == "Asteroid3")
				_gc.brojBodova += 3;
		}
		Destroy (other.gameObject);
	}
}
