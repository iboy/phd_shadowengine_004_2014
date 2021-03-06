﻿using UnityEngine;
using System.Collections;


public class FFT : MonoBehaviour
{
	
	#region vars
	public string CurrentAudioInput;
	
	private AudioObj[] audioObj = new AudioObj[2];
	
	private const int BANDS = 4;
	
	//public float[] curve = new float[BANDS]; //scale output of band analysis
	public float[] output = new float[BANDS];
	
	public string[] inputDevices;
	private int[] crossovers = new int[BANDS];
	private float[] freqData = new float[8192];
	private float[] band;
	
	public GameObject playerPrefab;
	private int index = 0;
	
	public static FFT Instance;
	private bool doSound = true;
	private int deviceNum;
	
	
	private struct AudioObj
	{
		public GameObject player;
		public AudioClip clip;
		public void SetClip(AudioClip c)
		{
			clip = c;
			player.audio.clip = c;
			/*
         slowing the playback down a small amount allows enough space between 
         recording and output so that analysis does not overtake the recording.
         this helps with stutter and distortion, but doesn't solve it completely
         */
			player.audio.pitch = .95f; 
		}
	}
	#endregion
	
	#region Unity Methods
	void Start()
	{
		Instance = this;
		
		crossovers[0] = 30;  //guesstimating sample lengths for frequency bands
		crossovers[1] = 50;
		crossovers[2] = 600;
		crossovers[3] = freqData.Length;
		
		band = new float[BANDS];
		output = new float[BANDS]; 
		
		for (int i = 0; i < audioObj.Length; i++)
		{
			audioObj[i].player = (GameObject)Instantiate(playerPrefab);
			audioObj[i].player.transform.parent = transform;
			audioObj[i].player.transform.position = Vector3.zero;
			audioObj[i].clip = new AudioClip();
		}
		
		inputDevices = new string[Microphone.devices.Length];
		deviceNum = Microphone.devices.Length - 1;
		
		for (int i = 0; i < Microphone.devices.Length; i++)
			inputDevices[i] = Microphone.devices[i].ToString();
		
		CurrentAudioInput = Microphone.devices[deviceNum].ToString();
		
		InvokeRepeating("Check", 0, 1.0f / 15.0f);
		StartCoroutine(StartRecord());
		
	}
	
	void Update()
	{
		KeyInput();
	}
	#endregion
	
	#region Actions
	
	private void Check()
	{
		if (!doSound)
			return;
		
		audioObj[index].player.audio.GetSpectrumData(freqData, 0, FFTWindow.Hamming);
		bool cutoff = false;
		int k = 0;
		for (int i = 0; i < freqData.Length; i++)
		{
			
			if (k > BANDS - 1)
				break;
			
			float d = freqData[i];
			float b = band[k];
			band[k] = (d > b) ? d : b;
			if (i > crossovers[k] - 10)
			{
				if (cutoff)
					break;
				
				output[k] = band[k];
				band[k] = 0;
				
				k++;
				if (i > crossovers[BANDS - 1] - 10)
					cutoff = true;
			}
		}
		
	}
	
	private IEnumerator StartRecord()
	{
		
		audioObj[index].clip = Microphone.Start(Microphone.devices[deviceNum], true, 5, 24000); 
		/*
         the longer the mic recording time, the less often there are "hiccups" in game performance
         but also due to being pitched down, the playback gradually falls farther behind the recording
       */
		
		print("recording to audioObj " + index);
		StartCoroutine(StartPlay(audioObj[index].clip));
		yield return new WaitForSeconds(5);
		StartCoroutine(StartRecord()); //swaps audio buffers, begins recording and playback of new buffer
		/* it is necessary to swap buffers, otherwise the audioclip quickly becomes too large and begins to slow down the system */
		
	}
	
	private IEnumerator StartPlay(AudioClip buffer)
	{
		audioObj[index].SetClip(buffer);
		yield return new WaitForSeconds(.01f);
		audioObj[index].player.SetActive(true);
		audioObj[index].player.audio.Play();
		
		audioObj[Mathf.Abs((index % 2) - 1)].player.audio.Stop();
		
		index++;
		if (index > 1)
			index = 0;
		
		
	}
	
	private void KeyInput()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			doSound = !doSound;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			deviceNum++;
			if (deviceNum > Microphone.devices.Length - 1)
				deviceNum = 0;
			CurrentAudioInput = Microphone.devices[deviceNum].ToString();
		}
	}
	#endregion
	
	
}