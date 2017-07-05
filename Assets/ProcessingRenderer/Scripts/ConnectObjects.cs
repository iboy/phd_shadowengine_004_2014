using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class ConnectObjects : MonoBehaviour {
	
	private Transform[] childObjects;
	private LineRenderer	_lineRenderer;
	private int				length;

	// Use this for initialization
	void Start () {
		
		_lineRenderer = GetComponent<LineRenderer>() as LineRenderer;
		
		childObjects = GetComponentsInChildren<Transform>();
		
		length = childObjects.Length;
		
		_lineRenderer.SetVertexCount(length);
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for( int i =0; i < length; i++)
		{
			_lineRenderer.SetPosition (i, childObjects[i].position);
		}	
	
	}
}
