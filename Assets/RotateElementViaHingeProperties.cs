using UnityEngine;
using System.Collections;

public class RotateElementViaHingeProperties : MonoBehaviour {

	public GameObject objectToRotate;
	public float springValue = 10;
	public KeyCode rotateColockwiseKey = KeyCode.G;
	public KeyCode rotateAntiClockwiseColockwiseKey = KeyCode.F;
	private HingeJoint myHingeJoint;
	private bool rotateClockwiseToggle;
	private bool rotateAnticlockwiseToggle;
	private JointSpring hingeSpring;
	private int countCCW;
	private int countCW;
	private float switcher = 1f;

	// Use this for initialization
	void Start () {
	
		if (objectToRotate != null) {

			myHingeJoint = objectToRotate.GetComponent(typeof(HingeJoint)) as HingeJoint;
			hingeSpring = myHingeJoint.spring;
			hingeSpring.spring = 10;
			switcher = 1f;

		}


	}
	
	// Update is called once per frame
	void Update () {
	


		if (Input.GetKeyUp(rotateColockwiseKey) ) {

			int myTargetPosInt = (int) hingeSpring.targetPosition;
			//countCW = countCW + 1;
			//
			//if (countCW == 1 ) {
			//	hingeSpring.targetPosition = 0;
			//
			//}
			//if ( hingeSpring.targetPosition == -1f) {
			//
			//	hingeSpring.targetPosition = 0;
			//}

			//if ( hingeSpring.targetPosition == -1f) {
			//	
			//	hingeSpring.targetPosition = 0;
			//	hingeSpring.targetPosition = -180f;
			//	myHingeJoint.spring = hingeSpring; 
			//	return;
			//}

			switch (myTargetPosInt)
			{
			case 0:
				//myHingeJoint.useSpring = false;
				hingeSpring.spring = springValue; 
				//hingeSpring.damper = 2;
				hingeSpring.targetPosition =  180f * switcher;
				myHingeJoint.spring = hingeSpring; 
				switcher = -1f;
				//myHingeJoint.useSpring = true;
				break;
			case 180:
				//myHingeJoint.useSpring = false;
				hingeSpring.spring = springValue; 
				//hingeSpring.damper = 2;
				hingeSpring.targetPosition =   0f * switcher;
				//hingeSpring.targetPosition =   hingeSpring.targetPosition + 179f;
				myHingeJoint.spring = hingeSpring; 
				switcher = 1f;
				//myHingeJoint.useSpring = true;
				break;
			case -180:
				//myHingeJoint.useSpring = false;
				hingeSpring.spring = springValue; 
				//hingeSpring.damper = 2;
				hingeSpring.targetPosition =   0f * switcher;
				//hingeSpring.targetPosition =   hingeSpring.targetPosition + 179f;
				myHingeJoint.spring = hingeSpring; 
				switcher = 1f;
				//myHingeJoint.useSpring = true;
				break;
			}
	

	
		}

		if (Input.GetKeyUp(rotateAntiClockwiseColockwiseKey)) {
			countCCW = countCCW + 1;

			int myTargetPosInt = (int) hingeSpring.targetPosition;

			//if (countCW > 1) { 
			//
			//	countCW = 0;
			//	hingeSpring.targetPosition = 0;
			//}
			//if ( hingeSpring.targetPosition == -1f) {
			//
			//	//myHingeJoint.useSpring = false;
			//	hingeSpring.spring = springValue; 
			//	//hingeSpring.damper = 2;
			//	hingeSpring.targetPosition = 0;
			//	hingeSpring.targetPosition = hingeSpring.targetPosition - 180f;
			//	myHingeJoint.spring = hingeSpring; 
			//	//myHingeJoint.useSpring = true;
			//	return;
			//}
			switch (myTargetPosInt)
			{
			case 0:
				hingeSpring.spring = springValue; 
				hingeSpring.targetPosition = -180f;
				myHingeJoint.spring = hingeSpring; 
				//switcher = -1f;
				break;
				
			case -180:
				hingeSpring.spring = springValue; 
				hingeSpring.targetPosition =  0f;
				myHingeJoint.spring = hingeSpring; 
				//switcher = -1f;

				break;
			}
		
		}

	}
}
