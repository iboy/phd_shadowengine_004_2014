using UnityEngine;
using System.Collections;


public class TogglePuppetMaterial : MonoBehaviour {
	
	public GameObject[] gameObjectsToToggle;
	public Color32 defaultTintColor = Color.white;
	public Color32 targetTintColor = Color.black;
	private Renderer rend;
	public Camera mainCamera; // orthographc
	public Camera perspectiveCamera;
	public KeyCode silhouetteMode = KeyCode.Z;
	public KeyCode defaultMaterialMode = KeyCode.X;
	public KeyCode grayscaleMode = KeyCode.C;
	public bool onlyChangeMaterialColorNotRenderer = false; 
	
	//private bool spaceToggle = false;
	
	// Use this for initialization
	void Start () {
		
		// cache all material colours
		//foreach (GameObject go in gameObjectsToToggle) {
		//	SetMaterialToBlack(go);
		//
		//}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(silhouetteMode)) {
			
			foreach (GameObject go in gameObjectsToToggle) {
				SetMaterialToBlack(go);
				
			}
			
		}
		
		if (Input.GetKeyDown(defaultMaterialMode)) {
			
			foreach (GameObject go in gameObjectsToToggle) {
				SetMaterialToDefault(go);
				
			}
			
		}
		
		if (Input.GetKeyDown(grayscaleMode)) {
			
			if (mainCamera != null) {
				GrayscaleEffect gs = mainCamera.GetComponent<GrayscaleEffect>();
				gs.enabled = !gs.enabled;
				//Debug.Log("Got the keypress");

				//GrayscaleEffect gsp = perspectiveCamera.GetComponent<GrayscaleEffect>();
				//gsp.enabled = !gsp.enabled;
				
			}
			
		}
		
		
	}
	
	void SetMaterialToBlack( GameObject obj ) {
		
		//Debug.Log(obj.name);
		
		if (obj.renderer !=null) {
			
			// slightly differnet approach - keeps some transparency
			obj.renderer.material.SetColor ("_Color", targetTintColor);

			if (onlyChangeMaterialColorNotRenderer == true) {
				// slightly differnet approach - makes totally black
				SpriteRenderer thisRenderer = obj.GetComponent<SpriteRenderer>();
				thisRenderer.color = targetTintColor;
			}
			
		}
		foreach (Transform child2 in obj.transform)
		{
			
			SetMaterialToBlack(child2.gameObject);
			
		}
		
	}
	
	void SetMaterialToDefault( GameObject obj ) {
		
		//Debug.Log(obj.name);
		
		if (obj.renderer !=null) {
			//rend = obj.GetComponent<Renderer>();
			
			//rend.material.color =  Color.blue;
			
			//obj.renderer.material.color =  Color.black;
			obj.renderer.material.SetColor ("_Color", defaultTintColor);

			if (onlyChangeMaterialColorNotRenderer == true) {
				// these are slightly different approaches.
				SpriteRenderer thisRenderer = obj.GetComponent<SpriteRenderer>();
				thisRenderer.color = defaultTintColor;
			}
		}
		foreach (Transform child in obj.transform)
		{
			
			SetMaterialToDefault(child.gameObject);
			
		}
		
	}
	
	
}
