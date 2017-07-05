using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowFpsCS : MonoBehaviour
{

	public Vector2 guiOffset = Vector2.zero;
	
	private GUIText gui;
	private float updateInterval = 1.0f;
	private double lastInterval ; // Last interval end time
	private int frames = 0; // Frames over current interval

	void Start ()
	{
		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
		
		guiOffset = new Vector2(10, Screen.height);
	}

	void OnDisable ()
	{
		if (gui)
			DestroyImmediate (gui.gameObject);
	}

	void Update ()
	{
#if !UNITY_FLASH
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval) {
			if (gui == null) {
				GameObject go = new GameObject ("FPS Display", typeof(GUIText));
				go.hideFlags = HideFlags.HideAndDontSave;
				go.transform.position =new Vector3 (0, 0, 0);
				gui = go.guiText;
				gui.pixelOffset = guiOffset;
				if(Screen.dpi < 160 )
				{
					gui.fontSize = 12;
				} else {
					gui.fontSize = 18;
				}
			}
			float fps = (float) (frames / (timeNow - lastInterval));
			float ms = 1000.0f / Mathf.Max (fps, 0.00001f);
			gui.text = ms.ToString ("f1") + "ms " + fps.ToString ("f2") + "FPS ";
			frames = 0;
			lastInterval = timeNow;
		}
#endif
	}

}
