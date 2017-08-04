using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class MoonWalkScript : MonoBehaviour {

	private float nowX = 0;
	private float nowY = 0;
	private float nowZ = 0;
	// Use this for initialization

	GameObject centerC,observer;

	//	private float currentX =0;
	//	private float preX = 0;
	//	private float currentY = 0;
	//	private float preY = 0;

	//for moving
	//	private Vector3 mouseP;

	//for moving like as astronote

	float plus =0.3f;
	bool jump =false;
	//	float friction = 0.99f;
	//	float accelerator = 1.03f;
	int counter =1;


	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Vector3 acc = Input.acceleration;
		var accY2 = Mathf.Pow (acc.y, 2);

		centerC = GameObject.Find ("Head");
		observer = GameObject.Find ("CardboardMain");

		float rot = centerC.transform.eulerAngles.y* Mathf.Deg2Rad;


		var zDir = Mathf.Cos (rot);
		var xDir = Mathf.Sin (rot);


		#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.Space)){
			nowZ = zDir;
			nowX = xDir;

			Vector3 p = new Vector3(nowX/4, nowY/4, nowZ/4);
			observer.transform.Translate(p);
		}
		#endif


		#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.J)) {
			jump = true;
		}
		#endif

		if (accY2 > 2.5) {  // s6 =  accY2 2.0, asus =  accY2 1.5 
			jump = true;
		}

		if (jump) {
			nowZ = zDir;
			nowX = xDir;
			counter++;
			if (counter < 30) {
				Vector3 p = new Vector3 (nowX*plus, 0.8f, nowZ*plus);
				observer.transform.Translate (p);
			}

			if (counter >= 30 && counter < 50) {
				Vector3 p = new Vector3 (nowX * plus, 0.6f, nowZ * plus);
				observer.transform.Translate (p);
			}

			if (counter >= 50 && counter < 70) {
				Vector3 p = new Vector3 (nowX * plus, -0.6f, nowZ * plus);
				observer.transform.Translate (p);
			}

			if (counter >= 70 && counter<90) {
				Vector3 p = new Vector3 (nowX*plus, -0.8f, nowZ*plus);
				observer.transform.Translate (p);
			}

			if (counter >= 90 && counter < 100) {
				Vector3 p = new Vector3 (nowX * plus, -0.5f, nowZ * plus);
				observer.transform.Translate (p);
			}


			if (counter == 100) {
				counter = 0;
//            plus =0.27f;
				jump = false;
			}
		}


		if(Input.GetKey (KeyCode.C)) {
			SceneManager.LoadScene ("//");
		}

	}
}
