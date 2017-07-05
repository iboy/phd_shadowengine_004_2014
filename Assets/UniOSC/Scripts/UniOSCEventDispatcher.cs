/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;


namespace UniOSC{
	/// <summary>
	/// This is the abstract class you should subclass from when you want to sent OSC data
	/// </summary>
	[ExecuteInEditMode]
	public abstract class UniOSCEventDispatcher : MonoBehaviour {

		#region public
		[HideInInspector]
		public string oscOutAddress ="/";
		[HideInInspector]
		public string oscOutIPAddress ;
		[HideInInspector]
		public int oscOutPort;
		//[HideInInspector]
		public float sendInterval=100;
		[HideInInspector]
		public bool useExplicitConnection;
		[HideInInspector]
		public UniOSCConnection explicitConnection;
		#endregion

		#region private
		protected OscMessage _OSCmsg ;
		protected UniOSCEventArgs _OSCeArg;
		protected System.Timers.Timer _sendIntervalTimer;
		protected bool _isOSCDirty;
		protected object _mylock = new object();
		[SerializeField,HideInInspector]
		protected bool _drawDefaultInspector = true;

		protected  void _OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
		{
			//Debug.Log(string.Format("The Elapsed event was raised at {0}", e.SignalTime));
			lock(_mylock){
				_isOSCDirty = true;
			}	
		}

		[SerializeField,HideInInspector]
		private List<UniOSCConnection> _myOSCConnections = new List<UniOSCConnection>() ;
		#endregion


		public virtual void Awake () {
			//Debug.Log("UniOSCEventDispatcher.Awake");
		}
		public virtual void Start () {

		}

		public virtual void OnEnable()
		{
			_Init();
		}

		private void _Init()
		{
			_myOSCConnections.Clear();
			_ConnectToOSCConnections();
			_SetupOSCMessage();
			#if UNITY_EDITOR
			if(!Application.isPlaying){
				UnityEditor.EditorApplication.update -= _Update;
				UnityEditor.EditorApplication.update += _Update;
			}
			#endif
		}

		protected virtual void _Update()
		{
			//Update();
		}


		protected void _OnConnectionOutStatusChanged(UniOSCConnection con)
		{
			if(!con.isConnectedOut)return;
			oscOutIPAddress = con.oscOutIPAddress;
			oscOutPort = con.oscOutPort;
			//force refresh of status
			enabled = !enabled;
			enabled = !enabled;
		}

		protected void _ConnectToOSCConnections()
		{
			//Debug.Log("UniOSCEventDispatcher._ConnectToOSCConnections");
			//Autowire the connection if no OSC connection is used via the Component Inspector  

			if(UniOSCConnection.Instances == null)return;

			foreach(var con in UniOSCConnection.Instances){
				
				if(con == null)continue;
				
				if(useExplicitConnection)
				{
					if(explicitConnection == null){
						Debug.Log("explicitConnection is Null!");
						break;//return;	
					}
					if(con != explicitConnection ) continue;
				}
				
				if(useExplicitConnection == true || (oscOutPort == con.oscOutPort && oscOutIPAddress == con.oscOutIPAddress)){
					//Debug.Log("con.OSCOutIPAddress:"+con.oscOutIPAddress +" con.Outport:"+con.oscOutPort);
					if(!_myOSCConnections.Contains(con) ){
						//_isAvailable = true;
						_myOSCConnections.Add(con);
						
						if( useExplicitConnection && explicitConnection != null){
							oscOutIPAddress = explicitConnection.oscOutIPAddress;
							oscOutPort = explicitConnection.oscOutPort;
							explicitConnection.ConnectionOutStatusChange-=_OnConnectionOutStatusChanged;
							explicitConnection.ConnectionOutStatusChange+=_OnConnectionOutStatusChanged;
						}
						
					}
				}
				
				
				
				
			}//for


			/*
				if(useExplicitConnection)
				{
					if(explicitConnection == null)return;
					if(!_myOSCConnections.Contains(explicitConnection) ){
						_myOSCConnections.Add(explicitConnection);
						oscOutIPAddress = explicitConnection.oscOutIPAddress;
						oscOutPort = explicitConnection.oscOutPort;
						explicitConnection.ConnectionOutStatusChange-=_OnConnectionOutStatusChanged;
						explicitConnection.ConnectionOutStatusChange+=_OnConnectionOutStatusChanged;
					}
					
				}
				else
				{ 
					foreach(var con in UniOSCConnection.Instances){
						if(con == null)continue;
						if(oscOutPort == con.oscOutPort && oscOutIPAddress == con.oscOutIPAddress){
							//Debug.Log("con.OSCOutIPAddress:"+con.oscOutIPAddress +" con.Outport:"+con.oscOutPort);
							if(!_myOSCConnections.Contains(con) ){_myOSCConnections.Add(con);}
						}


					}//foreach con


				}
				*/


			}
			
		protected void _DisconnectFromOSCConnections(){
			_myOSCConnections.Clear();
			if(explicitConnection != null) explicitConnection.ConnectionOutStatusChange-=_OnConnectionOutStatusChanged;//saftey
		}

		public virtual void OnDestroy(){
			_DisconnectFromOSCConnections();
		}

		public virtual void OnDisable(){
		//	Debug.Log("UniOSCEventDispatcher.OnDisable");
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.update -= _Update;
			#endif
			_DisconnectFromOSCConnections();
		}

		protected void _SetupOSCMessage ()
		{
			if(String.IsNullOrEmpty(oscOutAddress) || !oscOutAddress.StartsWith("/") )oscOutAddress = "/"+oscOutAddress;
			if(_OSCmsg == null)_OSCmsg = new OscMessage(oscOutAddress);
	
			_OSCeArg = new UniOSCEventArgs(oscOutPort,_OSCmsg);
			_OSCeArg.IPAddress = oscOutIPAddress;
		}

		protected void _SendOSCMessage(UniOSCEventArgs args)
		{
			foreach(var c in _myOSCConnections){
				if(c!= null) c.SendOSCMessage(this,args);
			}
		}

		/// <summary>
		/// Sends the OSC message.
		/// </summary>
		public void SendOSCMessage()
		{
			_SendOSCMessage(_OSCeArg);
		}

		public void AppendData(object _data)
		{
			if(_OSCmsg == null)_SetupOSCMessage();
			_OSCmsg.Append(_data);
		}

		public void ClearData(){
			if(_OSCmsg == null)return;
			_OSCmsg.ClearData();
		}

		public void StartSendIntervalTimer()
		{
			if(_sendIntervalTimer == null){
				_sendIntervalTimer = new System.Timers.Timer();
			}
			_sendIntervalTimer.Interval = sendInterval;
			_sendIntervalTimer.Elapsed-= _OnTimedEvent;
			_sendIntervalTimer.Elapsed+= _OnTimedEvent;
			_sendIntervalTimer.Enabled = true;
		}

		public void StopSendIntervalTimer()
		{
			if(_sendIntervalTimer == null)return;
			_sendIntervalTimer.Stop();
			_sendIntervalTimer.Elapsed-= _OnTimedEvent;
		}
	}
}