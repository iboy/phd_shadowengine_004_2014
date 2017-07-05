using UnityEngine;
using System.Collections;

public class KeysFireToggle : MonoBehaviour {


	public GameObject fireSmokeSystem001;
	public GameObject fireSmokeSystem002;
	public GameObject fireSmokeSystem003;
	public GameObject fireSmokeSystem004;
	public GameObject fireSmokeSystem005;

	public string key;
	private bool toggle = true;

	// Use this for initialization
	void Awake () {
		if (fireSmokeSystem001) { fireSmokeSystem001.particleSystem.enableEmission = false; }
		if (fireSmokeSystem002) { fireSmokeSystem002.particleSystem.enableEmission = false; }
		if (fireSmokeSystem003) { fireSmokeSystem003.particleSystem.enableEmission = false; }
		if (fireSmokeSystem004) { fireSmokeSystem004.particleSystem.enableEmission = false; }
		if (fireSmokeSystem005) { fireSmokeSystem005.particleSystem.enableEmission = false; }
		}
		
		// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp(key) && toggle == true) {

			Debug.Log("F Key pressed set to false");
			if (fireSmokeSystem001) { fireSmokeSystem001.particleSystem.enableEmission = true; Debug.Log("fireSmokeSystem001 is Set");}
			if (fireSmokeSystem002) { fireSmokeSystem002.particleSystem.enableEmission = true; }
			if (fireSmokeSystem003) { fireSmokeSystem003.particleSystem.enableEmission = true; }
			if (fireSmokeSystem004) { fireSmokeSystem004.particleSystem.enableEmission = true; }
			if (fireSmokeSystem005) { fireSmokeSystem005.particleSystem.enableEmission = true; }
			toggle = false;


		} else {
			if (Input.GetKeyUp(key) && toggle == false) {

				Debug.Log("F Key pressed set to true");
				if (fireSmokeSystem001) { fireSmokeSystem001.particleSystem.enableEmission = false; }
				if (fireSmokeSystem002) { fireSmokeSystem002.particleSystem.enableEmission = false; }
				if (fireSmokeSystem003) { fireSmokeSystem003.particleSystem.enableEmission = false; }
				if (fireSmokeSystem004) { fireSmokeSystem004.particleSystem.enableEmission = false; }
				if (fireSmokeSystem005) { fireSmokeSystem005.particleSystem.enableEmission = false; }
				toggle = true;

			}
		}


	}
}
