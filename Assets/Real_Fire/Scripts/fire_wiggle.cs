using UnityEngine;
using System.Collections;

public class fire_wiggle : MonoBehaviour {
	private float t=0f;
	private float wiggle_t=0f;
	public float fire_k=1f;
	private float initial_start_speed;
	private float initial_emission_rate;
	private float initial_lifetime;
	private float initial_size;
	private Vector3 initial_position;
	private float randomizer=0f;
	// Use this for initialization
	
	void Start () {
		randomizer = Random.Range(.75f,1.25f);//making each flame have burst randomly
	initial_start_speed=this.particleSystem.startSpeed;//saving initial flame properties
    initial_emission_rate=this.particleSystem.emissionRate;
	initial_lifetime = this.particleSystem.startLifetime;
	initial_size = this.particleSystem.startSize;
	initial_position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime*randomizer;
		wiggle_t+=Time.deltaTime*randomizer;
		
		//creating bursts of fire to make it more physically  realistic-->
		if (t>(2f+(2f-Mathf.Sin(wiggle_t)))){
			
		
		
		this.particleSystem.emissionRate+=(initial_emission_rate*.4f*fire_k-this.particleSystem.emissionRate)/30f;
			this.particleSystem.startLifetime+=(initial_lifetime*.9f*fire_k-this.particleSystem.startLifetime)/30f;
			
			if (this.particleSystem.emissionRate<initial_emission_rate*.42f*fire_k){
				this.particleSystem.emissionRate = initial_emission_rate*1.1f*fire_k;
					this.particleSystem.startLifetime=initial_lifetime*1.1f*fire_k;
				this.particleSystem.startSpeed=initial_start_speed*.7f*fire_k;
					this.particleSystem.startSize= initial_size*1.1f*fire_k;
				randomizer = Random.Range(.75f,1.25f);
				t=0f;
			}
		} else{
		this.particleSystem.emissionRate+=(initial_emission_rate-this.particleSystem.emissionRate)/30f;
			this.particleSystem.startLifetime+=(initial_lifetime-this.particleSystem.startLifetime)/100f;
			this.particleSystem.startSpeed+=(initial_start_speed-this.particleSystem.startSpeed)/30f;
			this.particleSystem.startSize+=(initial_size-this.particleSystem.startSize)/30f;
				
			
		}
	}
}
