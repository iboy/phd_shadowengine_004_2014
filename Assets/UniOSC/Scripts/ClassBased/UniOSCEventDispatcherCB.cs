/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;

namespace UniOSC{

	public abstract class UniOSCEventDispatcherCB : IDisposable {

		#region private
		private bool disposed = false;
		
		//[SerializeField]
		private bool _isEnabled;
		//public string oscAddress;

		private List<UniOSCConnection> _myOSCConnections = new List<UniOSCConnection>() ;

		protected OscMessage _OSCmsg ;
		protected UniOSCEventArgs _OSCeArg;
		protected System.Timers.Timer _sendIntervalTimer;
		protected bool _isOSCDirty;
		protected object _mylock = new object();
		
		protected  void _OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
		{
			//Debug.Log(string.Format("The Elapsed event was raised at {0}", e.SignalTime));
			lock(_mylock){
				_isOSCDirty = true;
			}	
			SendOSCMessage();
		}
		
		#endregion

		#region public

		public bool isEnabled{get{return _isEnabled;}}

		public string oscOutAddress {
			get;
			private set;
		}//="/";

		public string oscOutIPAddress{
			get;
			private set;
		}
		public int oscOutPort{
			get;
			private set;
		}
		public float sendInterval=100;
		public bool useExplicitConnection {
			get;
			private set;
		}
		public UniOSCConnection explicitConnection {
			get;
			private set;
		}

		public void SetExplicitConnection(UniOSCConnection newCon){
			if(useExplicitConnection) explicitConnection = newCon;
		}

		#endregion

		#region constructors
		
		public UniOSCEventDispatcherCB(string _oscOutAddress, string _oscOutIPAddress,int _oscPort )
		{
			oscOutAddress = _oscOutAddress;
			oscOutIPAddress = _oscOutIPAddress;
			oscOutPort = _oscPort;
			useExplicitConnection = false;
			Awake();
		}


		public UniOSCEventDispatcherCB(string _oscOutAddress, UniOSCConnection _explicitConnection)
		{
			oscOutAddress = _oscOutAddress;
			if(_explicitConnection != null){
			oscOutIPAddress = _explicitConnection.oscOutIPAddress;
			oscOutPort  = _explicitConnection.oscOutPort;
			}
			explicitConnection = _explicitConnection;
			useExplicitConnection = true;
			Awake();
		}

		#endregion

		public virtual void Awake()
		{}

		/// <summary>
		/// Enable this instance.
		/// </summary>
		public virtual void Enable()
		{
			_Init();
			_isEnabled = true;
		}

		/// <summary>
		/// Disable this instance.
		/// </summary>
		public virtual void Disable()
		{
			_DisconnectFromOSCConnections();
			_isEnabled = false;
		}
		
		public virtual void OnDestroy(){
			_DisconnectFromOSCConnections();
		}

		private void _Init()
		{
			_myOSCConnections.Clear();
			_ConnectToOSCConnections();
			_SetupOSCMessage();
		}

		protected void _OnConnectionOutStatusChanged(UniOSCConnection con)
		{
			if(!con.isConnectedOut)return;
			//Debug.Log("_OnConnectionOutStatusChanged");

			oscOutIPAddress = con.oscOutIPAddress;
			oscOutPort = con.oscOutPort;
			//force refresh
			if (_isEnabled){
				Disable();
				Enable();
			}
		}


		protected void _ConnectToOSCConnections()
		{
			//Debug.Log("UniOSCEventDispatcherCB._ConnectToOSCConnections");
			//Autowire the connection if no OSC connection is used via the Component Inspector  

			if(UniOSCConnection.Instances == null)return;

			bool _isAvailable = false;
			
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
						_isAvailable = true;
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

			if(!_isAvailable){
				Debug.LogWarning("No OSCConnection that fit the settings! No OSCMessages will be received!");
			}


			
		}
		
		protected void _DisconnectFromOSCConnections(){
			_myOSCConnections.Clear();
			if(explicitConnection != null) explicitConnection.ConnectionOutStatusChange-=_OnConnectionOutStatusChanged;//saftey
		}


		protected void _SetupOSCMessage ()
		{
			//Debug.Log("_SetupOSCMessage");
			if(String.IsNullOrEmpty(oscOutAddress) ||  !oscOutAddress.StartsWith("/"))oscOutAddress = "/"+oscOutAddress;//
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

		/// <summary>
		/// Append data.
		/// </summary>
		/// <param name="_data">_data.</param>
		public void AppendData(object _data)
		{
			if(_OSCmsg == null)_SetupOSCMessage();
			_OSCmsg.Append(_data);
		}

		/// <summary>
		/// Clears all data.
		/// </summary>
		public void ClearData(){
			if(_OSCmsg == null)return;
			_OSCmsg.ClearData();
		}

		/// <summary>
		/// Starts the send interval timer.
		/// This is useful when you need to send OSC data frequently. With the sendInterval property you specify the interval in milliseconds
		/// </summary>
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

		/// <summary>
		/// Stops the send interval timer.
		/// </summary>
		public void StopSendIntervalTimer()
		{
			if(_sendIntervalTimer == null)return;
			_sendIntervalTimer.Stop();
			_sendIntervalTimer.Elapsed-= _OnTimedEvent;
		}


		private void _Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Disable();
				}
				
				disposed = true;
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting  resources.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="UniOSC.UniOSCEventDispatcherCB"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="UniOSC.UniOSCEventDispatcherCB"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="UniOSC.UniOSCEventDispatcherCB"/>
		/// so the garbage collector can reclaim the memory that the <see cref="UniOSC.UniOSCEventDispatcherCB"/> was occupying.</remarks>
		public void Dispose() // Implement IDisposable
		{
			_Dispose(true);
			GC.SuppressFinalize(this);
		}

	}
}
