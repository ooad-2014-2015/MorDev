using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float speed = 10;
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime/speed;
		mat.mainTextureOffset = offset;
	}
}
