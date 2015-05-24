using UnityEngine;
using System.Collections;

public class AsteroidLogic : MonoBehaviour {
	private int snaga = 0;
	private int snagaConst = 0;

	public GameObject eksplozija;
	public GameObject eksplozijaIgraca;

	private GameObject controller;
	private GameController _gc;

	void Start () {
		controller = GameObject.FindWithTag("GC");
		_gc = controller.GetComponent<GameController> ();

		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * 5;
		if (gameObject.tag == "Asteroid1")
			snaga = snagaConst = 1;
		else if (gameObject.tag == "Asteroid2")
			snaga = snagaConst = 2;
		else if (gameObject.tag == "Asteroid3")
			snaga = snagaConst = 3;
	}

   void OnTriggerEnter(Collider neko)
	{
	 if (neko.tag == "Metak") {
			Destroy(neko.gameObject);
			snaga--;
			if(snaga == 0)
			{
				_gc.brojBodova += snagaConst;
				Instantiate(eksplozija, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
		if (neko.tag == "Igrac") {
			_gc.mrtav = true;
			_gc.gameOver();
			Destroy(gameObject);
			Destroy(neko.gameObject);
			Instantiate(eksplozijaIgraca, neko.transform.position, neko.transform.rotation);
			Instantiate(eksplozija, transform.position, transform.rotation);
		}
	}
}
