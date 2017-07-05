using UnityEngine;
using System.Collections;

public class WebCamGrab : MonoBehaviour {
	public string deviceName;
	WebCamTexture wct;
	string buttonText;
	
	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		deviceName = devices[0].name;
		buttonText = "Grab "+devices[0].name;
		wct = new WebCamTexture(deviceName, 640, 480, 12);

		renderer.material.mainTexture = wct;
		wct.Play();
	}
	
	// For photo variables
	
	public Texture2D heightmap;
	public Vector3 size = new Vector3(100, 10, 100);
	
	

	
	// For saving to the _savepath
	private string _SavePath = "Assets/screenshots/"; //Change the path here!
	int _CaptureCounter = 0;

	// make this public, the new UI system can trigger it from a button...
	public void TakeSnapshot()
	{
		Texture2D snap = new Texture2D(wct.width, wct.height);
		snap.SetPixels(wct.GetPixels());
		snap.Apply();
		
		System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
		++_CaptureCounter;
	}
}