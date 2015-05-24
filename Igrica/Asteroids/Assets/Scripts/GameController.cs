using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Factory pattern
public class AsteroidFactory {
	public void napraviAsteroid(int brojBodova)
	{
		if (brojBodova < 50) {
			var dummy = new Asteroid50 ();
		} else if (brojBodova < 100) {
			var dummy = new Asteroid100 ();
		} else if (brojBodova < 150) {
			var dummy = new Asteroid150 ();
		} else if (brojBodova < 200) {
			var dummy = new Asteroid200 ();
		} else {
			var dummy = new Asteroid500();
		}
	}
}

public abstract class Asteroid {
	public GameObject[] _asteroidi;
	public Vector3 pozicija;
	public Quaternion rotacija;
	public Vector3 brzina;
	public Asteroid (){}
}

public class Asteroid50 : Asteroid {
	public Asteroid50(){
		pozicija = new Vector3 (Random.Range(-17.5f, 17.5f), 0, 20);
		rotacija = Quaternion.identity;
		brzina = new Vector3 (0, 0, -1) * 5;
		GameObject asteroid = MonoBehaviour.Instantiate (GameObject.Find("GameController").GetComponent<GameController>().asteroidi[Random.Range (0, 6)], pozicija, rotacija) as GameObject;
		asteroid.GetComponent<Rigidbody>().velocity = brzina;
	}
}

public class Asteroid100 : Asteroid {
	public Asteroid100(){
		GameObject.Find ("GameController").GetComponent<GameController> ().time = 0.4f;
		pozicija = new Vector3 (Random.Range (-17.5f, 17.5f), 0, 20);
		rotacija = Quaternion.identity;
		brzina = new Vector3 (0, 0, -1) * 10;
		GameObject asteroid = MonoBehaviour.Instantiate (GameObject.Find("GameController").GetComponent<GameController>().asteroidi[Random.Range (0, 9)], pozicija, rotacija) as GameObject;
		asteroid.GetComponent<Rigidbody>().velocity = brzina;
	}
}

public class Asteroid150 : Asteroid {
	public Asteroid150(){
		int opcija = Random.Range (1, 3);
		if(opcija == 1) pozicija = new Vector3 (Random.Range (-17.5f, 17.5f), 0, 20);
		else pozicija = new Vector3 (18, 0, Random.Range(0, 20));
		rotacija = Quaternion.identity;
		brzina = new Vector3 (-0.5f, 0, -1) * 15;
		GameObject asteroid = MonoBehaviour.Instantiate (GameObject.Find("GameController").GetComponent<GameController>().asteroidi[Random.Range (0, 9)], pozicija, rotacija) as GameObject;
		asteroid.GetComponent<Rigidbody>().velocity = brzina;
	}
}

public class Asteroid200 : Asteroid {
	public Asteroid200(){
		GameObject.Find ("GameController").GetComponent<GameController> ().time = 0.3f;
		int opcija = Random.Range (1, 3);
		if(opcija == 1) pozicija = new Vector3 (Random.Range (-17.5f, 17.5f), 0, 20);
		else pozicija = new Vector3 (18, 0, Random.Range(0, 20));
		rotacija = Quaternion.identity;
		brzina = new Vector3 (-0.7f, 0, -1) * 20;
		GameObject asteroid = MonoBehaviour.Instantiate (GameObject.Find("GameController").GetComponent<GameController>().asteroidi[Random.Range (0, 9)], pozicija, rotacija) as GameObject;
		asteroid.GetComponent<Rigidbody>().velocity = brzina;
	}
}

public class Asteroid500 : Asteroid {
	public Asteroid500(){
		GameObject.Find ("GameController").GetComponent<GameController> ().time = 0.2f;
		int opcija = Random.Range (1, 3);
		if(opcija == 1) pozicija = new Vector3 (Random.Range (-17.5f, 17.5f), 0, 20);
		else pozicija = new Vector3 (18, 0, Random.Range(0, 20));
		rotacija = Quaternion.identity;
		brzina = new Vector3 (-1f, 0, -1f) * 25;
		GameObject asteroid = MonoBehaviour.Instantiate (GameObject.Find("GameController").GetComponent<GameController>().asteroidi[Random.Range (0, 9)], pozicija, rotacija) as GameObject;
		asteroid.GetComponent<Rigidbody>().velocity = brzina;
	}
}

// Observer pattern
public interface ISubject {
	void registerObserver(IObserver o);
	void unregisterObserver (IObserver o);
    void notifyObserver();
}

public interface IObserver{
	void update (int brojBodova);
}

public class GameController : MonoBehaviour, ISubject {
	public GameObject[] asteroidi;
	public bool mrtav;
	private ArrayList _observers;
	public int brojBodova;
	public Text txtBodovi;
	public Text tBodoviFinal;
	public Text ime;
	public GameObject gameOverPanel;

	public void registerObserver (IObserver newObserver)
	{
		_observers.Add (newObserver);
	}

	public void unregisterObserver (IObserver deleteObserver)
	{
		int observerIndex = _observers.IndexOf (deleteObserver);
		_observers.RemoveAt (observerIndex);

	}

	public void notifyObserver ()
	{
		foreach(IObserver observer in _observers)
		{
			observer.update(brojBodova);
		}
	}



	float dT = 0.0f;
	public float time = 0.5f;
	public AsteroidFactory asteroidFactory;
	public GameObject pozadina;
	public GameObject igrac;
	void Start () {
		GameObject.Find ("IntroAudio").GetComponent<AudioSource> ().volume = 0.3f;
		asteroidFactory = new AsteroidFactory ();
		_observers = new ArrayList ();
		brojBodova = 0;
		mrtav = false;
		txtBodovi.text = brojBodova.ToString ();
		pozadina = GameObject.Find("Pozadina");
		registerObserver (pozadina.GetComponent<PozadinaLogic> ());
	    igrac = GameObject.FindWithTag ("Igrac");
		registerObserver (igrac.GetComponent<IgracLogic> ());
	}
	
	void Update () {
	if (!mrtav) {
			if (dT > time) {
				asteroidFactory.napraviAsteroid (brojBodova);
				dT = 0;
			}
			notifyObserver ();
			txtBodovi.text = brojBodova.ToString ();
			dT += Time.deltaTime;
		}
	}

	public void gameOver()
	{
		gameOverPanel.GetComponent<CanvasGroup> ().interactable = true;
		gameOverPanel.GetComponent<CanvasGroup> ().alpha = 1;
		tBodoviFinal.text = brojBodova.ToString ();
	}

	public void unosRezultata()
	{
		if (ime.text != string.Empty) {
			string _ime = ime.text;
			int oldScore;
			string oldName;
			for(int i = 0; i < 10; i++){
				if(PlayerPrefs.HasKey(i + "HS")) {
					if(PlayerPrefs.GetInt(i + "HS") < brojBodova)
					{
						oldScore = PlayerPrefs.GetInt(i + "HS");
						oldName = PlayerPrefs.GetString(i +"HSName");
						PlayerPrefs.SetInt(i + "HS", brojBodova);
						PlayerPrefs.SetString(i + "HSName", _ime);

						brojBodova = oldScore;
						_ime = oldName;
					}
				} else {
					PlayerPrefs.SetInt(i + "HS", brojBodova);
					PlayerPrefs.SetString(i + "HSName", _ime);
					brojBodova = 0;
					_ime = "";
				}
				Application.LoadLevel("hs");
			}
		}
	}
}

