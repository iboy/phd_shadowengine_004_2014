using UnityEngine;
using System.Collections;

public class AnimatePanelInOut : MonoBehaviour {
	public Animator contentPanel;
	public GameObject panel;

	// Use this for initialization
	private float posX;
	private float posY;
	private float posZ;
	private float panelHeight; 
	private bool panelVisible = false;

	void Start () {
		RectTransform transform = contentPanel.gameObject.transform as RectTransform;
		Vector2 position = transform.anchoredPosition;
		panelHeight = transform.rect.height;
		position.y -= panelHeight;
		transform.anchoredPosition = position;
		//posX = panel.transform.position.x;
		//posZ = panel.transform.position.z;
		//posY = panelTransform.position.y;
		//panelHeight = panel.
		//posY = -100;
		//panel.transform.position = new Vector3 (posX,posY,posZ);
		//contentPanel.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.y < 10 && panelVisible == false) {

			togglePanel(true);


		} else {
			if (Input.mousePosition.y >panelHeight+10 && panelVisible == true) {
			togglePanel(false);

			}
		}
	}

	void togglePanel(bool state) {
		//bool isHidden = contentPanel.GetBool("isHidden");
		if (state == true) {

			contentPanel.enabled = true;
			
			//bool isHidden = contentPanel.GetBool("isHidden");
			contentPanel.SetBool("isHidden", false);

			Debug.Log ("Panel is in View");
			panelVisible = true;
			//panel.transform.position = new Vector3 (posX,0,posZ);

		} else {


			Debug.Log ("Panel is hidden");
			contentPanel.SetBool("isHidden", true);
			//contentPanel.enabled = false;
			panelVisible = false;
			//panel.transform.position = new Vector3 (posX,-100,posZ);
		}

	}

}
