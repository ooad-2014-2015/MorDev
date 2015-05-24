using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HSLoader : MonoBehaviour {
	public Text[] _lista;

	void Start () {
		for (int i = 0; i < 10; i++) {
		if(PlayerPrefs.HasKey(i + "HS")){
				if(PlayerPrefs.GetInt(i + "HS") != 0)
				_lista[i].text = (i + 1).ToString()+ ". " + PlayerPrefs.GetString(i + "HSName") + " - " + PlayerPrefs.GetInt(i + "HS");
				else _lista[i].text = "";
			}
		}
	}
	
}
