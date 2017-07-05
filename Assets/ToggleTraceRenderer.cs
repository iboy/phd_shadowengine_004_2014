using UnityEngine;
using System.Collections;

public class ToggleTraceRenderer : MonoBehaviour {
	public Camera puppetCam;
	public float traceInterval=.1f;
	private bool toggle = false;
	private bool inLoop = false;
	// Use this for initialization
	void Start () {
	
	}


	public void ToggleTraceVisualisor() {

		//Debug.Log("GUI pressed");
		if (toggle == false) {

			puppetCam.clearFlags = CameraClearFlags.Nothing;
			toggle = true;
			//InvokeRepeating("ToggleCam", .1f, 0.1F);
			//StartCoroutine(WaitToToggle(toggle));
			//puppetCam.enabled = true;

		} else  {

			puppetCam.clearFlags = CameraClearFlags.Color;
			toggle = false;

		}


	}

	void ToggleCam(){

		puppetCam.enabled = !puppetCam.enabled;

	}
	void Update () {
		//if (inLoop == true && toggle == true) { puppetCam.enabled = true; WaitToToggle(); } else { inLoop = false; return;} 
		//if (toggle == false) {
		//	return;
		//} else {

			//StartCoroutine("ToggleCamera");
			//Debug.Log ("Hello from trace update");


		//};



	}

	IEnumerator WaitToToggle(bool toggle) {

		while (true) {
		Debug.Log ("Hello from WaitToToggle");
		//puppetCam.enabled = !puppetCam.enabled;
		puppetCam.enabled=false;
		yield return StartCoroutine(DoPuppetCameraToggleOn(traceInterval));
		}
		//	yield return new WaitForSeconds(traceInterval);
		}

//		IEnumerator DoPuppetCameraToggleOff(float waitTime) {
//			Debug.Log ("Hello from DoPuppetCameraToggleOff");
//			//puppetCam.enabled = false;
//			yield return StartCoroutine(DoPuppetCameraToggleOn(4f));
//		
//			//inLoop = true;
//		}
//		
	IEnumerator DoPuppetCameraToggleOn(float waitTime) {
		Debug.Log ("Hello from DoPuppetCameraToggleOn");
		puppetCam.enabled = !puppetCam.enabled;
		yield return new WaitForSeconds(0.8f);


		//inLoop = true;
	}

}
