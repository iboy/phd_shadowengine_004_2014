// Ian Grant
// Display touch points
// 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchTracker : MonoBehaviour {
	
	
	public GameObject[] TouchPointSprites;
	public GameObject[] TouchPointControllers;
	public bool displayTouchPointsSwitch = true;
	public bool disableOtherDragScripts = false;


	private Vector2[] touchPosition;

	private Vector3 mousePosition;



	public float touchOverlayZ 	=  	6f;
	public float trackSpeed 	= 	0.1f;


	public float 	spring 		=	50.0f;
	public float  	damper 		= 	5.0f;
	public float  	drag 		= 	10.0f;
	public float  	angularDrag = 	5.0f;
	public float  	distance 	= 	0.2f;
	public bool 	attachTouchDragsToCenterOfMass = false;
	public Camera mainCamera;
	public Camera mainPerspectiveCamera;
	public float perspectiveMultiplier = 1.0f;

	//static List<GameObject> controllerTouchObjects = new List<GameObject>();
	private SpringJoint springJoint;
	private Ray ray;
	private bool[] kinematicFlag = new bool[11];
	//int controllerTouchObjectsSize;

	void Start() {

		foreach (GameObject touchGraphic in TouchPointSprites) {
			touchGraphic.SetActive(false);
		}
		if (disableOtherDragScripts == true) {
			
			mainCamera.GetComponent<DragRigidbody>().enabled = false;
			
		} 


	}
	
	void Update() {


		if (Input.touchCount > 0)
		{
			//Touch touch = Input.GetTouch(0);


			foreach (Touch touch in Input.touches) {


				if (displayTouchPointsSwitch) {
					DisplayTouchPoints(touch);
				}
				//RaycastHit hit;

				TouchToController(touch);

				//DragrigidbodyWithTouch(touch);
				//fingerCount++;
			}
		}

	}

	void DisplayTouchPoints ( Touch touch ) {



		//Debug.Log ("Handle Touch: "+touch.fingerId+" Began");

		switch (touch.phase) {

		case TouchPhase.Began:
			Debug.Log ("Handle Touch: "+touch.fingerId+" Began");
			//TouchPointSprites[touch.fingerId].SetActive(true); // moved this to start from the new position - rather than the last stored position
			//TouchPointSprites[touch.fingerId].SetActive(true);
			break;

		case TouchPhase.Moved:
			//Debug.Log ("Handle Touch: "+touch.fingerId+" Moved");

			Vector3 touchDeltaPosition = touch.position; // remember get touch is zero indexed.
			//touchDeltaPosition = Camera.main.ScreenToWorldPoint(touchDeltaPosition);
			if (mainPerspectiveCamera !=null & mainPerspectiveCamera.enabled==true) {
				//touchDeltaPosition = mainPerspectiveCamera.ScreenToWorldPoint(touchDeltaPosition);

				TouchPointSprites[touch.fingerId].SetActive(true);
				touchDeltaPosition = GetWorldPositionOnPlane(touch.position, touchDeltaPosition.z-.14f);
				//TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, touchDeltaPosition.z-.14f); // perspective camera mode
				TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier, TouchPointControllers[touch.fingerId].transform.position.z); // orthographic camera mode. TODO change the -2 to 0. But adjust all instances.


			}

			if (mainCamera.enabled==true) {
				//Debug.Log("We are in touch moved");
				touchDeltaPosition = mainCamera.ScreenToWorldPoint(touchDeltaPosition);
				TouchPointSprites[touch.fingerId].SetActive(true);
				//TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, touchOverlayZ); // orthographic camera mode. TODO change the -2 to 0. But adjust all instances.
				TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier, TouchPointControllers[touch.fingerId].transform.position.z); // orthographic camera mode. TODO change the -2 to 0. But adjust all instances.
				

			}


				break;


		case TouchPhase.Ended:
			//Debug.Log ("Handle Touch: "+touch.fingerId+" Ended");
			TouchPointSprites[touch.fingerId].SetActive(false);
			break;
		}
	}
	
	void TouchToController ( Touch touch ) {
	
		ray = mainCamera.ScreenPointToRay(touch.position);
		if (mainPerspectiveCamera !=null & mainPerspectiveCamera.enabled==true) {
			 ray = mainPerspectiveCamera.ScreenPointToRay(touch.position);
		}

		if ( mainCamera.enabled==true) {

			 ray = mainCamera.ScreenPointToRay(touch.position);
		}

		//bool dragit = false; // flag to signal we're ready to drag...
		RaycastHit hit = new RaycastHit();

		//Debug.Log ("Handle Touch: "+touch.fingerId+" Began");
		
		switch (touch.phase) {
			
		case TouchPhase.Began:
		
			//Debug.Log ("Handle Touch: "+touch.fingerId+" Began");
			TouchPointControllers[touch.fingerId].SetActive(true);

			//hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("Touch: "+touch.fingerId+"  hit"+hit.collider.name);

				if (hit.rigidbody) { // is it a rigidbody
					
					if(!hit.rigidbody.isKinematic) {  // is it NOT set to isKinematic? i.e not to move
						

						springJoint = TouchPointControllers[touch.fingerId].GetComponent<SpringJoint>();
						springJoint.transform.position = hit.point;
						
						// check where the anchor is supposed to go
						if (attachTouchDragsToCenterOfMass) {
							
							// check these values
							Vector3 anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
							anchor = springJoint.transform.InverseTransformPoint(anchor);
							//anchor = springJoint.transform.TransformPoint(anchor);
							springJoint.anchor = anchor;
							
						} else {
							springJoint.anchor = Vector3.zero;
						}
						
						// set spring settings
						springJoint.spring = spring;
						springJoint.damper = damper;
						springJoint.maxDistance = distance;
						springJoint.connectedBody = hit.rigidbody;
						
						//StartCoroutine (DragObject( hit.distance, touch, dragit));
						
				 


					} else {

					// handle the switching of isKinematic true rigidbodies here.

						// Here we are detecting control points (in a spring network) that are
						// set to isKinematic = true
						// we treat them that same as a isKinematic = false rigidbody, but switch the isKinematic first.
						// Then we switch it back on touch phase ended.


						springJoint = TouchPointControllers[touch.fingerId].GetComponent<SpringJoint>();
						springJoint.transform.position = hit.point;
						
						// check where the anchor is supposed to go
						if (attachTouchDragsToCenterOfMass) {
							
							// check these values
							Vector3 anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
							anchor = springJoint.transform.InverseTransformPoint(anchor);
							//anchor = springJoint.transform.TransformPoint(anchor);
							springJoint.anchor = anchor;
							
						} else {
							springJoint.anchor = Vector3.zero;
						}
						
						// set spring settings
						springJoint.spring = spring;
						springJoint.damper = damper;
						springJoint.maxDistance = distance;
						springJoint.connectedBody = hit.rigidbody;

						// set the flag and switch the swtich - this may be failing and we might need an array of bool flags - one per touch.
						kinematicFlag[touch.fingerId] = true;
						springJoint.connectedBody.isKinematic = false;

					}
					
				} // end of rigid body test
				
			} // end of first hit test
			
			else {
				
				//if (springJoint.connectedBody) { Destroy(springJoint.gameObject); } // destroys the object if it was connected to a kinematic rigidbody
				
			}


			break;
			
		case TouchPhase.Moved:
			//Debug.Log ("Handle Touch: "+touch.fingerId+" Moved");

			Vector3 touchDeltaPosition = touch.position; // remember get touch is zero indexed.
			//touchDeltaPosition = Camera.main.ScreenToWorldPoint(touchDeltaPosition);



			if ( mainCamera.enabled==true) {
				//TouchPointControllers[touch.fingerId].SetActive(true);
				touchDeltaPosition = mainCamera.ScreenToWorldPoint(touchDeltaPosition);
				TouchPointControllers[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier, TouchPointControllers[touch.fingerId].transform.position.z);
				//Debug.Log ("Moving stuff around");

				if  (displayTouchPointsSwitch == true) {
				TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier, TouchPointControllers[touch.fingerId].transform.position.z); // orthographic camera mode. TODO change the -2 to 0. But adjust all instances.
				}
			}

			if (mainPerspectiveCamera !=null & mainPerspectiveCamera.enabled==true) {
				//TouchPointControllers[touch.fingerId].SetActive(true);
				perspectiveMultiplier = 1.0f;
				touchDeltaPosition = GetWorldPositionOnPlane(touch.position, 0);
				TouchPointControllers[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier,TouchPointControllers[touch.fingerId].transform.position.z);

				if  (displayTouchPointsSwitch == true) {
					TouchPointSprites[touch.fingerId].transform.position = new Vector3(touchDeltaPosition.x*perspectiveMultiplier, touchDeltaPosition.y*perspectiveMultiplier, TouchPointControllers[touch.fingerId].transform.position.z); // orthographic camera mode. TODO change the -2 to 0. But adjust all instances.
				}


			} 

			break;
			
			
		case TouchPhase.Ended:
			//Debug.Log ("Handle Touch: "+touch.fingerId+" Ended");
			if (springJoint) {
		
				if (kinematicFlag[touch.fingerId] == true) {
					//hit.rigidbody.isKinematic = true;
					//Debug.Log(kinematicFlag);
					TouchPointControllers[touch.fingerId].GetComponent<SpringJoint>().connectedBody.isKinematic = true;
					kinematicFlag[touch.fingerId] = false; 
					
				}

				TouchPointControllers[touch.fingerId].GetComponent<SpringJoint>().connectedBody = null;
			
			
		
			
			
			}



			TouchPointControllers[touch.fingerId].SetActive(false);

			break;
		}
	}

	// Handle Mouse Moves as well as touch
	//



	// this function corrects the ray values for the perspective camera with real wild settings. All movement was constrianed
	// to the middle of the screen, with no left and right movment at all.
	/*
	 * When using a perspective camera, changing the Z position actually changes where the object appears on the screen. 
	 * Think of it this way, in perspective camera, the farther the object is, the more it appears to be in the middle, 
	 * even if the X and Y remain the same. The closer it gets, the more it moves to the side, until it gets close enough 
	 * to pass to your left or right.
	 * http://answers.unity3d.com/questions/566519/camerascreentoworldpoint-in-perspective.html
	*/

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray2 = mainPerspectiveCamera.ScreenPointToRay(screenPosition);

		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray2, out distance);
		return ray.GetPoint(distance);

	}

	
}