using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroButtonLogic : MonoBehaviour {
	public void LoadInfoScene()
	{
		Application.LoadLevel ("info");
	}
    public void LoadIntroScene()
	{
		//PlayerPrefs.DeleteAll ();
		Application.LoadLevel ("intro");
	}
    public void LoadMainScene()
	{
	Application.LoadLevel ("main");
	}
    public void LoadHsScene()
	{
		Application.LoadLevel("hs");
	}
    public void Utrni()
	{
		Application.Quit ();
	}
}
