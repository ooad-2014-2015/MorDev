using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float BrzinaRotacijeX = 1;
	public float BrzinaRotacijeY = 10;
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime/BrzinaRotacijeY;
	    offset.x += Time.deltaTime / BrzinaRotacijeX;
		mat.mainTextureOffset = offset;
	}
}
