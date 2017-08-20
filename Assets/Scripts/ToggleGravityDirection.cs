using UnityEngine;
using System.Collections;

public class ToggleGravityDirection : MonoBehaviour {

	public KeyCode gravityToggleKey = KeyCode.G;
	private bool toggleState = false;
	// Use this for initialization
	void Start () {
		toggleState = false;
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKeyDown(gravityToggleKey)) {

			if (toggleState == true)
			{
				Physics.gravity = new Vector3(0, -9.81f, 0);
				toggleState = false;

			} else {

				Physics.gravity = new Vector3(0, 0, 9.81f);
				toggleState = true;
			}
		}

	}
}
