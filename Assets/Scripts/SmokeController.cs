using UnityEngine;
using System.Collections;

public class SmokeController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		this.particleSystem.enableEmission = false;
	}

}
