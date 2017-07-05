using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardController002 : MonoBehaviour {

	public Button button;
	// Use this for initialization
	void Start () {
	
		//button.onClick.AddListener(() => { MyFunction(); MyOtherFunction(); });

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Debug.Log("R pressed.");
			button.onClick.AddListener(() => {
				//handle click here
				Debug.Log("In onclick addlistener");
			});
			//button.
		}
	}
}
