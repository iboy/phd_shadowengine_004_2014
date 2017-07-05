using UnityEngine;
using System.Collections;


// A script to attach / reattach an object to an anchor point.
// It is used in a 'rag-doll' setup where characters are
// puppeteered using 'control objects'
// It is set up to 're-orientate' the detached object so is
// meant for use with hats, pipes, walking sticks, pies on trays etc.

// Set up host object with a box collider with 'is trigger' = true
// around the zone that will need to touch the detachable/attachable object's
// box collider (also with 'is trigger = true')
// Parent an empty game object to the host object to mark the anchor point
// the detachable object needs to be pre-attached to the host object
// with a hinge joint with break forces set to a sensible factor 
// I exert the pulling force on the object with a 'controller' gameobject
// that is a rigidbody connected to the detachable object with a spring


// TODO generalise this script - DONE
// TODO to a version for 2D physics

public class AttachDetachObject3D : MonoBehaviour {
	public GameObject detachableObject;
	public GameObject hostObject;
	public GameObject attachPointAnchor;
	public bool _useLimits = false;
	public float maxLimits = 10f;
	public float minLimits = -10f;
	public float _breakForce = 40f;
	public float _breakTorque = 40f;


	private Vector3 cachedPosition;
	private Quaternion cachedRotation;
	private JointLimits limits;
	// Use this for initialization
	void Start () {
	
		if (detachableObject == null)return;
		cachedPosition = detachableObject.transform.position;
		cachedRotation = detachableObject.transform.rotation;
		limits = detachableObject.rigidbody.hingeJoint.limits;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		if (detachableObject == null)return;
		if (other.gameObject.name == detachableObject.name) {

			if (detachableObject.rigidbody.hingeJoint) {
				Debug.Log("the detachableObject on "+gameObject.name+" has connected");

			} else {
				detachableObject.rigidbody.isKinematic = true;
				//pipe.transform.rotation = cachedRotation;
				detachableObject.transform.rotation = attachPointAnchor.transform.rotation;
				detachableObject.transform.position = attachPointAnchor.transform.position;
				//pipe.transform.parent = pipeAnchor.transform;
				detachableObject.AddComponent<HingeJoint>();
				detachableObject.rigidbody.hingeJoint.axis = new Vector3 (0,0,1);
				detachableObject.rigidbody.hingeJoint.breakForce = _breakForce;
				detachableObject.rigidbody.hingeJoint.breakTorque = _breakTorque;
				detachableObject.rigidbody.hingeJoint.useLimits = _useLimits;
				limits.max = maxLimits;
				limits.min = minLimits;
				detachableObject.rigidbody.isKinematic = false;
				//pipe.transform.localRotation = cachedRotation;
				//pipe.transform.localPosition = cachedPosition;
				detachableObject.rigidbody.hingeJoint.connectedBody = hostObject.rigidbody;
				//	pipe.rigidbody.isKinematic = false;
			}


			//other.gameObject.HingeJoint.ConnectedBody = this;
		}
	}
}
