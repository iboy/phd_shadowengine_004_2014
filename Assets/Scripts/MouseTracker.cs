using UnityEngine;
using System.Collections;


/// <summary>
/// Drag a rigidbody with the mouse using a spring joint.
/// </summary>
[RequireComponent(typeof(Rigidbody))]

public class MouseTracker : MonoBehaviour {

	public Camera mainCamera;
	public Camera perspectiveCamera;
	public float mouseForce = 600;
	public float mouseDragDamping = 6;
	private bool isMouseDown = false;
	Transform jointTrans;
	float dragDepth;
	
	void OnMouseDown ()
	{
		if (Input.touchCount ==1) { return; } 
		isMouseDown = true; 

		HandleInputBegin (Input.mousePosition);
		//Debug.Log("We've got mouse action - mousie down: x = "+Input.mousePosition.x+" y = "+Input.mousePosition.y);
	}
	
	void OnMouseUp ()
	{   
		isMouseDown = false; 
		HandleInputEnd (Input.mousePosition);
	}
	
	void OnMouseDrag ()
	{
		if (Input.touchCount > 0) { return; } 
		//Debug.Log("We've got mouse action - mousie dragging: x = "+Input.mousePosition.x+" y = "+Input.mousePosition.y);
		HandleInput (Input.mousePosition);
	}
	
	public void HandleInputBegin (Vector3 screenPosition)
	{
		var ray = mainCamera.ScreenPointToRay (screenPosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer ("3DTouchablePuppetObject")) {
				dragDepth = CameraPlane.CameraToPointDepth (mainCamera, hit.point);
				jointTrans = AttachJoint (hit.rigidbody, hit.point);
			}
		}
	}
	
	public void HandleInput (Vector3 screenPosition)
	{
		if (jointTrans == null)
			return;
		var worldPos = mainCamera.ScreenToWorldPoint (screenPosition);
		jointTrans.position = CameraPlane.ScreenToWorldPlanePoint (mainCamera, dragDepth, screenPosition);
	}
	
	public void HandleInputEnd (Vector3 screenPosition)
	{

		//if (Input.touchCount == 0 && isMouseDown == false) {
		if (jointTrans != null) {
			Destroy (jointTrans.gameObject);
		}
		//}
		
	}
	
	Transform AttachJoint (Rigidbody rb, Vector3 attachmentPosition)
	{
		GameObject go = new GameObject ("Mouse Dragger");
		//go.hideFlags = HideFlags.HideInHierarchy; 
		go.transform.position = attachmentPosition;
		
		var newRb = go.AddComponent<Rigidbody> ();
		newRb.isKinematic = true;
		
		var joint = go.AddComponent<ConfigurableJoint> ();
		joint.connectedBody = rb;
		joint.axis = new Vector3(0,0,1);
		joint.configuredInWorldSpace = true;
		joint.xDrive = NewJointDrive (mouseForce, mouseDragDamping);
		joint.yDrive = NewJointDrive (mouseForce, mouseDragDamping);
		joint.zDrive = NewJointDrive (mouseForce, mouseDragDamping);
		joint.slerpDrive = NewJointDrive (mouseForce, mouseDragDamping);
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		
		return go.transform;
	}
	
	private JointDrive NewJointDrive (float force, float damping)
	{
		JointDrive drive = new JointDrive ();
		drive.mode = JointDriveMode.Position;
		drive.positionSpring = force;
		drive.positionDamper = damping;
		drive.maximumForce = Mathf.Infinity;
		return drive;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
