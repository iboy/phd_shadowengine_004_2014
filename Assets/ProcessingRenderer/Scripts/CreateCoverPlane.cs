using UnityEngine;
using System.Collections;

public class CreateCoverPlane : MonoBehaviour {
	
	public Material cameraCoverMaterial ;
	private GameObject cameraCoverObject;

	// Use this for initialization
	void Start () {
		
		CreateCameraCoverPlane();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject CreateCameraCoverPlane ()
	{
		cameraCoverObject = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cameraCoverObject.renderer.material = cameraCoverMaterial;	
		cameraCoverObject.transform.parent = transform;
		cameraCoverObject.transform.localPosition = new Vector3(0,0, 1.55f);
		cameraCoverObject.transform.localRotation = Quaternion.identity;
		cameraCoverObject.transform.localEulerAngles = new Vector3 (cameraCoverObject.transform.localEulerAngles.x, cameraCoverObject.transform.localEulerAngles.y, 180f);
		cameraCoverObject.transform.localScale = new Vector3(1.6f,1.5f, 1.5f);	;	
	
		return cameraCoverObject;		
	}
}
