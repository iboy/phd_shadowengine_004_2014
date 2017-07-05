using UnityEngine;
using System.Collections;

public class ChangePuppetDrag : MonoBehaviour {

	[HideInInspector]
	[Range(0.01f, 100)]
	public float rigidbodyMass;
	[HideInInspector]
	[Range(0, 50)]
	public float rigidbodyDrag;
	[HideInInspector]
	[Range(0, 50)]
	public float rigidbodyAngularDrag;


	public Rigidbody rigidbody001;
	public Rigidbody rigidbody002;
	public Rigidbody rigidbody003;
	public Rigidbody rigidbody004;
	public Rigidbody rigidbody005;
	public Rigidbody rigidbody006;
	public Rigidbody rigidbody007;
	public Rigidbody rigidbody008;
	public Rigidbody rigidbody009;
	public Rigidbody rigidbody010;

	private float rigidbody001Mass;
	private float rigidbody001Drag;
	private float rigidbody001AngularDrag;
	private float rigidbody002Mass;
	private float rigidbody002Drag;
	private float rigidbody002AngularDrag;
	private float rigidbody003Mass;
	private float rigidbody003Drag;
	private float rigidbody003AngularDrag;
	private float rigidbody004Mass;
	private float rigidbody004Drag;
	private float rigidbody004AngularDrag;
	private float rigidbody005Mass;
	private float rigidbody005Drag;
	private float rigidbody005AngularDrag;
	private float rigidbody006Mass;
	private float rigidbody006Drag;
	private float rigidbody006AngularDrag;
	private float rigidbody007Mass;
	private float rigidbody007Drag;
	private float rigidbody007AngularDrag;
	private float rigidbody008Mass;
	private float rigidbody008Drag;
	private float rigidbody008AngularDrag;
	private float rigidbody009Mass;
	private float rigidbody009Drag;
	private float rigidbody009AngularDrag;
	private float rigidbody010Mass;
	private float rigidbody010Drag;
	private float rigidbody010AngularDrag;

	private string helpText = "The sliders below change both editor and runtime drag and angular drag values. Use only at runtime to preserve any custom drag settings you have setup.";
	// Use this for initialization
	void Start () {
		if (rigidbody001) {
			rigidbody001Mass = rigidbody001.mass;
			rigidbody001Drag = rigidbody001.drag;
			rigidbody001AngularDrag = rigidbody001.angularDrag;
		
			rigidbody001.mass = rigidbodyMass;
			rigidbody001.drag = rigidbodyDrag;
			rigidbody001.angularDrag = rigidbodyAngularDrag;

		}
		if (rigidbody002) {
			rigidbody002Mass = rigidbody002.mass;
			rigidbody002Drag = 			rigidbody002.drag;
			rigidbody002AngularDrag = 	rigidbody002.angularDrag;

			rigidbody002.mass = rigidbodyMass;
			rigidbody002.drag = rigidbodyDrag;
			rigidbody002.angularDrag = rigidbodyAngularDrag;
		}
		if (rigidbody003) {
			rigidbody003Mass = rigidbody003.mass;
			rigidbody003Drag = 			rigidbody003.drag;
			rigidbody003AngularDrag = 	rigidbody003.angularDrag;

			rigidbody003.mass = rigidbodyMass;
			rigidbody003.drag = rigidbodyDrag;
			rigidbody003.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody004) {
			rigidbody004Mass = rigidbody004.mass;
			rigidbody004Drag = 			rigidbody004.drag;
			rigidbody004AngularDrag = 	rigidbody004.angularDrag;

			rigidbody004.mass = rigidbodyMass;
			rigidbody004.drag = rigidbodyDrag;
			rigidbody004.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody005) {

			rigidbody005Mass = rigidbody005.mass;
			rigidbody005Drag = 			rigidbody005.drag;
			rigidbody005AngularDrag = 	rigidbody005.angularDrag;

			rigidbody005.mass = rigidbodyMass;
			rigidbody005.drag = rigidbodyDrag;
			rigidbody005.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody006) {
			rigidbody006Mass = 			rigidbody006.mass;
			rigidbody006Drag = 			rigidbody006.drag;
			rigidbody006AngularDrag = 	rigidbody006.angularDrag;

			rigidbody006.mass = rigidbodyMass;
			rigidbody006.drag = 		rigidbodyDrag;
			rigidbody006.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody007) {
			rigidbody007Mass = rigidbody007.mass;
			rigidbody007Drag = 			rigidbody007.drag;
			rigidbody007AngularDrag = 	rigidbody007.angularDrag;

			rigidbody007.mass = rigidbodyMass;
			rigidbody007.drag = rigidbodyDrag;
			rigidbody007.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody008) {
			rigidbody008Mass = rigidbody008.mass;
			rigidbody008Drag = 			rigidbody008.drag;
			rigidbody008AngularDrag = 	rigidbody008.angularDrag;

			rigidbody008.mass = rigidbodyMass;
			rigidbody008.drag = rigidbodyDrag;
			rigidbody008.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody009) {
			rigidbody009Mass = rigidbody009.mass;
			rigidbody009Drag = 			rigidbody009.drag;
			rigidbody009AngularDrag = 	rigidbody009.angularDrag;

			rigidbody009.mass = rigidbodyMass;
			rigidbody009.drag = rigidbodyDrag;
			rigidbody009.angularDrag = rigidbodyAngularDrag;
			
		}
		if (rigidbody010) {
			rigidbody010Mass = rigidbody010.mass;
			rigidbody010Drag = 			rigidbody010.drag;
			rigidbody010AngularDrag = 	rigidbody010.angularDrag;

			rigidbody010.mass = rigidbodyMass;
			rigidbody010.drag = rigidbodyDrag;
			rigidbody010.angularDrag = rigidbodyAngularDrag;
			
		}
		
		
	}





	public void ChangeRigidbodyAngularDrag (float slider) {

		//Debug.Log("Called ChangeDrag from the editor");
		if (rigidbody001) {
			rigidbody001.angularDrag = slider;
		}
		if (rigidbody002) {
			rigidbody002.angularDrag = slider;
		}
		if (rigidbody003) {
			rigidbody003.angularDrag = slider;
		}
		if (rigidbody004) {
			rigidbody004.angularDrag = slider;
		}
		if (rigidbody005) {
			rigidbody005.angularDrag = slider;
		}
		if (rigidbody006) {
			rigidbody006.angularDrag = slider;
		}
		if (rigidbody007) {
			rigidbody007.angularDrag = slider;
		}
		if (rigidbody008) {
			rigidbody008.angularDrag = slider;
		}
		if (rigidbody009) {
			rigidbody009.angularDrag = slider;
		}
		if (rigidbody010) {
			rigidbody010.angularDrag = slider;
		}

	}
	public void ChangeRigidbodyDrag (float slider) {
		
		//Debug.Log("Called ChangeDrag from the editor");
		if (rigidbody001) {
			rigidbody001.drag = slider;
		}
		if (rigidbody002) {
			rigidbody002.drag = slider;
		}
		if (rigidbody003) {
			rigidbody003.drag = slider;
		}
		if (rigidbody004) {
			rigidbody004.drag = slider;
		}
		if (rigidbody005) {
			rigidbody005.drag = slider;
		}
		if (rigidbody006) {
			rigidbody006.drag = slider;
		}
		if (rigidbody007) {
			rigidbody007.drag = slider;
		}
		if (rigidbody008) {
			rigidbody008.drag = slider;
		}
		if (rigidbody009) {
			rigidbody009.drag = slider;
		}
		if (rigidbody010) {
			rigidbody010.drag = slider;
		}
	
	}

	public void ResetDragValuesToDefaults()

	{

		if (rigidbody001) {
			rigidbody001.mass = rigidbody001Mass;
			rigidbody001.drag = rigidbody001Drag;
			rigidbody001.angularDrag = rigidbody001AngularDrag;
		}
		if (rigidbody002) {
			rigidbody002.mass = 		rigidbody002Mass;
			rigidbody002.drag = 		rigidbody002Drag;
			rigidbody002.angularDrag = 	rigidbody002AngularDrag;
		}
		if (rigidbody003) {
			rigidbody003.mass = 		rigidbody003Mass;
			rigidbody003.drag = 		rigidbody003Drag;
			rigidbody003.angularDrag = 	rigidbody003AngularDrag;
		}
		if (rigidbody004) {
			rigidbody004.mass = 		rigidbody004Mass;
			rigidbody004.drag = 		rigidbody004Drag;
			rigidbody004.angularDrag = 	rigidbody004AngularDrag;

		}
		if (rigidbody005) {
			rigidbody005.mass = 		rigidbody005Mass;
			rigidbody005.drag = 		rigidbody005Drag;
			rigidbody005.angularDrag = 	rigidbody005AngularDrag;
		}
		if (rigidbody006) {
			rigidbody006.mass = 		rigidbody006Mass;
			rigidbody006.drag = 		rigidbody006Drag;
			rigidbody006.angularDrag = 	rigidbody006AngularDrag;
		}
		if (rigidbody007) {
			rigidbody007.mass = 		rigidbody007Mass;
			rigidbody007.drag = 		rigidbody007Drag;
			rigidbody007.angularDrag = 	rigidbody007AngularDrag;
		}
		if (rigidbody008) {
			rigidbody008.mass = 		rigidbody008Mass;
			rigidbody008.drag = 		rigidbody008Drag;
			rigidbody008.angularDrag = 	rigidbody008AngularDrag;
		}
		if (rigidbody009) {
			rigidbody009.mass = 		rigidbody009Mass;
			rigidbody009.drag = 		rigidbody009Drag;
			rigidbody009.angularDrag = 	rigidbody009AngularDrag;
		}
		if (rigidbody010) {
			rigidbody010.mass = 		rigidbody010Mass;
			rigidbody010.drag = 		rigidbody010Drag;
			rigidbody010.angularDrag = 	rigidbody010AngularDrag;
		}
		
	}

	public void ChangeRigidbodyMass (float slider) {
		
		//Debug.Log("Called ChangeDrag from the editor");
		if (rigidbody001) {
			rigidbody001.mass = slider;
		}
		if (rigidbody002) {
			rigidbody002.mass = slider;
		}
		if (rigidbody003) {
			rigidbody003.mass = slider;
		}
		if (rigidbody004) {
			rigidbody004.mass = slider;
		}
		if (rigidbody005) {
			rigidbody005.mass = slider;
		}
		if (rigidbody006) {
			rigidbody006.mass = slider;
		}
		if (rigidbody007) {
			rigidbody007.mass = slider;
		}
		if (rigidbody008) {
			rigidbody008.mass = slider;
		}
		if (rigidbody009) {
			rigidbody009.mass = slider;
		}
		if (rigidbody010) {
			rigidbody010.mass = slider;
		}
		
	}

	void OnApplicationQuit() {

		ResetDragValuesToDefaults();
	}

	public string GetText() {
		return helpText;

	}

}

