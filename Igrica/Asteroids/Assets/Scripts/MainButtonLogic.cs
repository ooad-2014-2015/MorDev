using UnityEngine;
using System.Collections;


public class MainButtonLogic : MonoBehaviour {
	public void LoadInfoScene()
	{
		Application.LoadLevel ("info");
	}
 public void LoadIntroScene()
	{
		Application.LoadLevel ("intro");
	}
 public void LoadMainScene()
	{
		Application.LoadLevel ("main");
	}
 public void LoadHsScene()
	{
        // to be implemented
	}
 public void Utrni()
	{
		// serijalizacija high scorea
		Application.Quit ();
	}
}
