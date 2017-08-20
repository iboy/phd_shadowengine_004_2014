using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	public Transform pointChin;
	public Transform pointHand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ( pointChin != null || pointHand !=null ) {
			Vector3 chinAnchorPosition = new Vector3(pointChin.position.x, pointChin.position.y, pointChin.position.z);
			Vector3 handAnchorPosition = new Vector3(pointHand.position.x, pointHand.position.y, pointHand.position.z);
			Debug.DrawLine(chinAnchorPosition, handAnchorPosition, Color.black);
			DrawLineInGameView(chinAnchorPosition, handAnchorPosition, Color.black);
		}
	}


	void DrawLineInGameView(Vector3 start, Vector3 end, Color color, float duration = 0.002f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.01f, 0.01f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
	}
}
