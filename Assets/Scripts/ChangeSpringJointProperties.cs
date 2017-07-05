using UnityEngine;
using System.Collections;

public class ChangeSpringJointProperties : MonoBehaviour {

	[HideInInspector]
	[Range(0, 500)]
	public float springjointSpring;
	[HideInInspector]
	[Range(0, 500)]
	public float springjointDamper;
	[HideInInspector]
	[Range(0, 100)]
	public float springjointMaxDistance;


	public SpringJoint springjoint001;
	public SpringJoint springjoint002;
	public SpringJoint springjoint003;
	public SpringJoint springjoint004;
	public SpringJoint springjoint005;
	public SpringJoint springjoint006;
	public SpringJoint springjoint007;
	public SpringJoint springjoint008;
	public SpringJoint springjoint009;
	public SpringJoint springjoint010;

	private float springjoint001Spring;
	private float springjoint001Damper;
	private float springjoint001MaxDistance;
	private float springjoint002Spring;
	private float springjoint002Damper;
	private float springjoint002MaxDistance;
	private float springjoint003Spring;
	private float springjoint003Damper;
	private float springjoint003MaxDistance;
	private float springjoint004Spring;
	private float springjoint004Damper;
	private float springjoint004MaxDistance;
	private float springjoint005Spring;
	private float springjoint005Damper;
	private float springjoint005MaxDistance;
	private float springjoint006Spring;
	private float springjoint006Damper;
	private float springjoint006MaxDistance;
	private float springjoint007Spring;
	private float springjoint007Damper;
	private float springjoint007MaxDistance;
	private float springjoint008Spring;
	private float springjoint008Damper;
	private float springjoint008MaxDistance;
	private float springjoint009Spring;
	private float springjoint009Damper;
	private float springjoint009MaxDistance;
	private float springjoint010Spring;
	private float springjoint010Damper;
	private float springjoint010MaxDistance;

	private string helpText = "The sliders below change both editor and runtime spring property values. Use only at runtime to preserve any custom spring settings you have made to the referenced springjoints.";
	// Use this for initialization
	void Start () {
		if (springjoint001) {
			springjoint001Spring = springjoint001.spring;
			springjoint001Damper = springjoint001.damper;
			springjoint001MaxDistance = springjoint001.maxDistance;
		
			springjoint001.spring = springjointSpring;
			springjoint001.damper = springjointDamper;
			springjoint001.maxDistance = springjointMaxDistance;

		}
		if (springjoint002) {
			springjoint002Spring = springjoint002.spring;
			springjoint002Damper = 			springjoint002.damper;
			springjoint002MaxDistance = 	springjoint002.maxDistance;

			springjoint002.spring = springjointSpring;
			springjoint002.damper = springjointDamper;
			springjoint002.maxDistance = springjointMaxDistance;
		}
		if (springjoint003) {
			springjoint003Spring = springjoint003.spring;
			springjoint003Damper = 			springjoint003.damper;
			springjoint003MaxDistance = 	springjoint003.maxDistance;

			springjoint003.spring = springjointSpring;
			springjoint003.damper = springjointDamper;
			springjoint003.maxDistance = springjointMaxDistance;
			
		}
		if (springjoint004) {
			springjoint004Spring = springjoint004.spring;
			springjoint004Damper = 			springjoint004.damper;
			springjoint004MaxDistance = 	springjoint004.maxDistance;

			springjoint004.spring = springjointSpring;
			springjoint004.damper = springjointDamper;
			springjoint004.maxDistance = springjointMaxDistance;
			
		}
		if (springjoint005) {

			springjoint005Spring = springjoint005.spring;
			springjoint005Damper = 			springjoint005.damper;
			springjoint005MaxDistance = 	springjoint005.maxDistance;

			springjoint005.spring = springjointSpring;
			springjoint005.damper = springjointDamper;
			springjoint005.maxDistance = springjointMaxDistance;
			
		}
		if (springjoint006) {
			springjoint006Spring = 			springjoint006.spring;
			springjoint006Damper = 			springjoint006.damper;
			springjoint006MaxDistance = 	springjoint006.maxDistance;

			springjoint006.spring = 		springjointSpring;
			springjoint006.damper = 		springjointDamper;
			springjoint006.maxDistance = 	springjointMaxDistance;
			
		}
		if (springjoint007) {
			springjoint007Spring = 			springjoint007.spring;
			springjoint007Damper = 			springjoint007.damper;
			springjoint007MaxDistance = 	springjoint007.maxDistance;

			springjoint007.spring = 		springjointSpring;
			springjoint007.damper = 		springjointDamper;
			springjoint007.maxDistance = 	springjointMaxDistance;
			
		}
		if (springjoint008) {
			springjoint008Spring = springjoint008.spring;
			springjoint008Damper = 			springjoint008.damper;
			springjoint008MaxDistance = 	springjoint008.maxDistance;

			springjoint008.spring = springjointSpring;
			springjoint008.damper = springjointDamper;
			springjoint008.maxDistance = springjointMaxDistance;
			
		}
		if (springjoint009) {
			springjoint009Spring = springjoint009.spring;
			springjoint009Damper = 			springjoint009.damper;
			springjoint009MaxDistance = 	springjoint009.maxDistance;

			springjoint009.spring = springjointSpring;
			springjoint009.damper = springjointDamper;
			springjoint009.maxDistance = springjointMaxDistance;
			
		}
		if (springjoint010) {
			springjoint010Spring = springjoint010.spring;
			springjoint010Damper = 			springjoint010.damper;
			springjoint010MaxDistance = 	springjoint010.maxDistance;

			springjoint010.spring = springjointSpring;
			springjoint010.damper = springjointDamper;
			springjoint010.maxDistance = springjointMaxDistance;
			
		}
		
		
	}





	public void ChangeSpringJointMaxDistance (float slider) {

		//Debug.Log("Called ChangeDamper from the editor");
		if (springjoint001) {
			springjoint001.maxDistance = slider;
		}
		if (springjoint002) {
			springjoint002.maxDistance = slider;
		}
		if (springjoint003) {
			springjoint003.maxDistance = slider;
		}
		if (springjoint004) {
			springjoint004.maxDistance = slider;
		}
		if (springjoint005) {
			springjoint005.maxDistance = slider;
		}
		if (springjoint006) {
			springjoint006.maxDistance = slider;
		}
		if (springjoint007) {
			springjoint007.maxDistance = slider;
		}
		if (springjoint008) {
			springjoint008.maxDistance = slider;
		}
		if (springjoint009) {
			springjoint009.maxDistance = slider;
		}
		if (springjoint010) {
			springjoint010.maxDistance = slider;
		}

	}
	public void ChangeSpringJointDamper (float slider) {
		
		//Debug.Log("Called ChangeDamper from the editor");
		if (springjoint001) {
			springjoint001.damper = slider;
		}
		if (springjoint002) {
			springjoint002.damper = slider;
		}
		if (springjoint003) {
			springjoint003.damper = slider;
		}
		if (springjoint004) {
			springjoint004.damper = slider;
		}
		if (springjoint005) {
			springjoint005.damper = slider;
		}
		if (springjoint006) {
			springjoint006.damper = slider;
		}
		if (springjoint007) {
			springjoint007.damper = slider;
		}
		if (springjoint008) {
			springjoint008.damper = slider;
		}
		if (springjoint009) {
			springjoint009.damper = slider;
		}
		if (springjoint010) {
			springjoint010.damper = slider;
		}
	
	}

	public void ResetSpringJointValuesToDefaults()

	{

		if (springjoint001) {
			springjoint001.spring = springjoint001Spring;
			springjoint001.damper = springjoint001Damper;
			springjoint001.maxDistance = springjoint001MaxDistance;
		}
		if (springjoint002) {
			springjoint002.spring = 		springjoint002Spring;
			springjoint002.damper = 		springjoint002Damper;
			springjoint002.maxDistance = 	springjoint002MaxDistance;
		}
		if (springjoint003) {
			springjoint003.spring = 		springjoint003Spring;
			springjoint003.damper = 		springjoint003Damper;
			springjoint003.maxDistance = 	springjoint003MaxDistance;
		}
		if (springjoint004) {
			springjoint004.spring = 		springjoint004Spring;
			springjoint004.damper = 		springjoint004Damper;
			springjoint004.maxDistance = 	springjoint004MaxDistance;

		}
		if (springjoint005) {
			springjoint005.spring = 		springjoint005Spring;
			springjoint005.damper = 		springjoint005Damper;
			springjoint005.maxDistance = 	springjoint005MaxDistance;
		}
		if (springjoint006) {
			springjoint006.spring = 		springjoint006Spring;
			springjoint006.damper = 		springjoint006Damper;
			springjoint006.maxDistance = 	springjoint006MaxDistance;
		}
		if (springjoint007) {
			springjoint007.spring = 		springjoint007Spring;
			springjoint007.damper = 		springjoint007Damper;
			springjoint007.maxDistance = 	springjoint007MaxDistance;
		}
		if (springjoint008) {
			springjoint008.spring = 		springjoint008Spring;
			springjoint008.damper = 		springjoint008Damper;
			springjoint008.maxDistance = 	springjoint008MaxDistance;
		}
		if (springjoint009) {
			springjoint009.spring = 		springjoint009Spring;
			springjoint009.damper = 		springjoint009Damper;
			springjoint009.maxDistance = 	springjoint009MaxDistance;
		}
		if (springjoint010) {
			springjoint010.spring = 		springjoint010Spring;
			springjoint010.damper = 		springjoint010Damper;
			springjoint010.maxDistance = 	springjoint010MaxDistance;
		}
		
	}

	public void ChangeSpringJointSpring (float slider) {
		
		//Debug.Log("Called ChangeDamper from the editor");
		if (springjoint001) {
			springjoint001.spring = slider;
		}
		if (springjoint002) {
			springjoint002.spring = slider;
		}
		if (springjoint003) {
			springjoint003.spring = slider;
		}
		if (springjoint004) {
			springjoint004.spring = slider;
		}
		if (springjoint005) {
			springjoint005.spring = slider;
		}
		if (springjoint006) {
			springjoint006.spring = slider;
		}
		if (springjoint007) {
			springjoint007.spring = slider;
		}
		if (springjoint008) {
			springjoint008.spring = slider;
		}
		if (springjoint009) {
			springjoint009.spring = slider;
		}
		if (springjoint010) {
			springjoint010.spring = slider;
		}
		
	}

	void OnApplicationQuit() {

		ResetSpringJointValuesToDefaults();
	}

	public string GetText() {
		return helpText;

	}

}

