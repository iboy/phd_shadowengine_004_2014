using UnityEngine;
using System.Collections;



public class ToggleCamera : MonoBehaviour {
	
	public Camera perspectiveCamera;
	public Camera orthographicCamera;
	public TouchTracker touchTracker;
	public KeyCode orthoPerspectiveCameraToggleKey = KeyCode.P;
	public KeyCode dofToggleKey = KeyCode.D;
	public KeyCode vignetteToggleKey = KeyCode.BackQuote;
	public KeyCode blurToggleKey = KeyCode.Backslash;
	public KeyCode antialiasingToggleKey = KeyCode.Semicolon;

	

	void Start () {
		if (perspectiveCamera != null) {
		perspectiveCamera.enabled = false; 
		}

		orthographicCamera.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(orthoPerspectiveCameraToggleKey)) {

			if (perspectiveCamera != null) {
			
				perspectiveCamera.enabled = !perspectiveCamera.enabled;
				orthographicCamera.enabled = !orthographicCamera.enabled;

			
				if (perspectiveCamera.enabled) {
					if (touchTracker != null) {		
						touchTracker.displayTouchPointsSwitch = true;	// this is trying to fix the issue with the touch track in perspective space... it turns off the touch indicator.
					}
			
				}

				if (orthographicCamera.enabled) {
					if (touchTracker != null) {
						touchTracker.displayTouchPointsSwitch = true;
					}
				}
			}
		}
	
		if (Input.GetKeyDown(dofToggleKey)) {
				if (perspectiveCamera != null) {
					DepthOfFieldScatter dof = perspectiveCamera.gameObject.GetComponent<DepthOfFieldScatter>();
					dof.enabled = !dof.enabled;
				}
			}

		

		if (Input.GetKeyDown(blurToggleKey)) {
			
			if (orthographicCamera.enabled) {
				Blur blo = orthographicCamera.gameObject.GetComponent<Blur>();
				blo.enabled = !blo.enabled;

			}

			if (perspectiveCamera != null) {
				if (perspectiveCamera.enabled) {
					Blur blp = perspectiveCamera.gameObject.GetComponent<Blur>();
					blp.enabled = !blp.enabled;
				
				}
			}
		}

		if (Input.GetKeyDown(antialiasingToggleKey)) {
			
			if (orthographicCamera.enabled) {
				AntialiasingAsPostEffect aao = orthographicCamera.gameObject.GetComponent<AntialiasingAsPostEffect>();
				aao.enabled = !aao.enabled;
				
			}
			
			if (perspectiveCamera != null) {
				if (perspectiveCamera.enabled) {
					AntialiasingAsPostEffect aap = perspectiveCamera.gameObject.GetComponent<AntialiasingAsPostEffect>();
					aap.enabled = !aap.enabled;
					
				}
			}
		}

		if (Input.GetKeyDown(vignetteToggleKey)) {
			
			if (orthographicCamera.enabled) {

				Vignetting vigo = orthographicCamera.gameObject.GetComponent<Vignetting>();
				vigo.enabled = !vigo.enabled;
			}
			if (perspectiveCamera != null) {
			if (perspectiveCamera.enabled) {
					Vignetting vigp = perspectiveCamera.gameObject.GetComponent<Vignetting>();
					vigp.enabled = !vigp.enabled;
				}
			}
		}
			
	}

}
