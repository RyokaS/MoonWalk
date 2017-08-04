using UnityEngine;
using System.Collections;

public class meteorite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 p = new Vector3 (-10f, -10f, 15f);
		transform.Translate (p);
	
	}
}
