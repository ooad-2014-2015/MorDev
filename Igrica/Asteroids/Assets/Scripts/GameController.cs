using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
	public GameObject[] asteroidi;
	public GameObject pozadina;
	public Scroll _scroll;

	int brojZivota;
	public int brojBodova;
	public Text txtBodovi;
	float dT = 0.0f;
	float time = 1.0f;

	void Start () {
		brojZivota = 3;
		brojBodova = 0;
		txtBodovi.text = brojBodova.ToString ();
		pozadina = GameObject.FindWithTag ("Pozadina");
		_scroll = pozadina.GetComponent<Scroll> ();
	
	}
	
	void Update () {
		if (dT > time) {

			//brojBodova += 10;
			txtBodovi.text = brojBodova.ToString();
			dT = 0.0f;
			if(brojBodova < 500)
			{
				Vector3 pozicija = new Vector3(18, 0, Random.Range(2, 20));
				Quaternion rotacija = Quaternion.identity;

				GameObject asteroid = Instantiate(asteroidi[Random.Range(0, 8)], pozicija, rotacija) as GameObject; 
				asteroid.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1) * 10;

				if(_scroll.BrzinaRotacijeX < Random.Range(-50, 50))
				{
				_scroll.BrzinaRotacijeX += 2;
					if(_scroll.BrzinaRotacijeX == 0) _scroll.BrzinaRotacijeX = 1;
				
					_scroll.BrzinaRotacijeY += 3;
					if(_scroll.BrzinaRotacijeY == 0) _scroll.BrzinaRotacijeY = 1;
				}

			    //pozicija = new Vector3(Random.Range(-10, 10), 0, 20);
				//Instantiate(asteroidi[Random.Range(0, 8)], pozicija, rotacija);
			}
		}
		dT += Time.deltaTime;
	}
}
