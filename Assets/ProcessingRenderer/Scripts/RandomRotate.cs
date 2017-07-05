using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {
	
	public float speed = 1;
	
	private float x = 0;
	private float y = 0;
	private float z = 0;

	// Use this for initialization
	void Start () {
		
	x = Random.value * speed;
	y = Random.value * speed;
	z = Random.value * speed;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(x,y,z);
	
	}
}
