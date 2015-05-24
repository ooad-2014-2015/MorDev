using UnityEngine;
using System.Collections;

public class PozadinaLogic : MonoBehaviour, IObserver {

	public float BrzinaRotacijeX = 100;
	public float BrzinaRotacijeY = 20;

	public void update (int brojBodova)
	{
		if (brojBodova >= 40) {
			if (brojBodova <= 70) {
				BrzinaRotacijeX = 50;
				BrzinaRotacijeY = 15;
			} else if (brojBodova <= 100) {
				BrzinaRotacijeX = 20;
				BrzinaRotacijeY = 10;
			} else if (brojBodova <= 200) {
				BrzinaRotacijeX = 10;
				BrzinaRotacijeY = 5;
			} else if (brojBodova <= 500) {
				BrzinaRotacijeX = 5;
				BrzinaRotacijeY = 3;
			} else {
				BrzinaRotacijeX = 3;
				BrzinaRotacijeY = 2;
			}
		}
	}

	void Update () {
		rotirajPozadinu ();
	}

	public void rotirajPozadinu()
	{
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		
		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime/BrzinaRotacijeY;
		offset.x += Time.deltaTime / BrzinaRotacijeX;
		mat.mainTextureOffset = offset;
	}
}
