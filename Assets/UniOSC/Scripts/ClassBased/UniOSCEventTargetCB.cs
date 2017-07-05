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

namespace UniOSC{

	/// <summary>
	/// UniOSC event target for class based scripting.
	/// This is the abstract class you should subclass from
	/// </summary>
	[Serializable]
	public abstract class UniOSCEventTargetCB : IDisposable{

		#region private

		private bool disposed = false;

		private bool _isEnabled;

		#endregion

		#region public

		public event EventHandler<UniOSCEventArgs> OSCMessageReceived;

		public bool isEnabled{get{return _isEnabled;}}

		public string oscAddress
		{
			get;
			private set;
		}

		public bool receiveAllAddresses{
			get;
			private set;
		}	

		public bool useExplicitConnection{
			get;
			private set;
		}

		public UniOSCConnection explicitConnection{
			get;
			private set;
		}

		public int oscPort{
			get;
			private set;
		}

		public bool receiveAllPorts{
			get;
			private set;
		}

		public void SetExplicitConnection(UniOSCConnection newCon){
			if(useExplicitConnection) explicitConnection = newCon;
		}


		public Dictionary<UniOSCConnection,List<UniOSCMappingItem>> ConnectToDict = new Dictionary<UniOSCConnection,List<UniOSCMappingItem>>();

		#endregion

		#region protected

		protected List<string> _oscAddresses = new List<string>() ;

		#endregion

		//private int _oscPort;
		//public UniOSCCodeEventTarget(){}

	
		#region constructors

		public UniOSCEventTargetCB(int _oscPort)
		{
			//Debug.Log("UniOSCEventTargetCB.Construktor");
			oscPort = _oscPort;
			receiveAllPorts = false;
			receiveAllAddresses = true;
			useExplicitConnection = false;
			Awake();
		}
		public UniOSCEventTargetCB(string _oscAddress)
		{
			//Debug.Log("UniOSCEventTargetCB.Construktor");
			if(!_oscAddresses.Contains(_oscAddress)) _oscAddresses.Add(_oscAddress);
			receiveAllPorts = true;
			receiveAllAddresses = false;
			useExplicitConnection = false;
			Awake();
		}

		public UniOSCEventTargetCB(string _oscAddress,int _oscPort)
		{
			//Debug.Log("UniOSCEventTargetCB.Construktor");
			oscPort = _oscPort;
			receiveAllPorts = false;
			receiveAllAddresses = false;
			if(!_oscAddresses.Contains(_oscAddress)) _oscAddresses.Add(_oscAddress);
			useExplicitConnection = false;
		}

		public UniOSCEventTargetCB(UniOSCConnection con)
		{
			//Debug.Log("UniOSCEventTargetCB.Construktor");
			//oscPort = con.oscPort;
			receiveAllPorts = false;
			receiveAllAddresses = true;
			useExplicitConnection = true;
			explicitConnection = con;
			Awake();
		}

		public UniOSCEventTargetCB( string _oscAddress,UniOSCConnection con )
		{
			//Debug.Log("UniOSCEventTargetCB.Construktor");
			//oscPort = con.oscPort;
			receiveAllPorts = false;
			receiveAllAddresses = false;
			if(!_oscAddresses.Contains(_oscAddress)) _oscAddresses.Add(_oscAddress);
			useExplicitConnection = true;
			explicitConnection = con;
			Awake();
		}

		#endregion

		~UniOSCEventTargetCB()
		{
			//Debug.Log("UniOSCEventTargetCB.Destruktor");
			_Dispose(false);
		}

		public virtual void Awake()
		{
			//Debug.Log("UniOSCEventTargetCB.Awake");
		}

		/// <summary>
		/// Enable this instance.
		/// </summary>
		public virtual void Enable()
		{
			//Debug.Log("UniOSCEventTargetCB.Enable");
			_Init();
			_isEnabled = true;
		}

		/// <summary>
		/// Disable this instance.
		/// </summary>
		public virtual void Disable()
		{
			//Debug.Log("UniOSCEventTargetCB.Disable");
			_DisconnectFromDispatchers();
			_isEnabled = false;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="UniOSC.UniOSCEventTargetCB"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="UniOSC.UniOSCEventTargetCB"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="UniOSC.UniOSCEventTargetCB"/> so
		/// the garbage collector can reclaim the memory that the <see cref="UniOSC.UniOSCEventTargetCB"/> was occupying.</remarks>
		public void Dispose() // Implement IDisposable
		{
			_Dispose(true);
			GC.SuppressFinalize(this);
		}

		#region privateMethods
		private void _Init(){
			//if(_oscAddresses.Count == 0 && !_oscAddresses.Contains(oscAddress)) _oscAddresses.Add(oscAddress);
			
			_DisconnectFromDispatchers();
			_ConnectToDispatchers();
		}


		private  void _ConnectToDispatchers()
		{
			//Debug.Log("UniOSCEventTargetCB._ConnectToDispatchers");
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
				
				if( useExplicitConnection == true || ( receiveAllPorts || con.oscPort == oscPort)){

					if(!ConnectToDict.ContainsKey(con)){
						//Debug.Log("ADDED:"+con.oscPort);
						_isAvailable = true;
						ConnectToDict.Add(con,new List<UniOSCMappingItem>());
						con.OSCMessageReceived-= _OnOSCMessageReceived;
						con.OSCMessageReceived+= _OnOSCMessageReceived;
						if( useExplicitConnection && explicitConnection != null){
							explicitConnection.ConnectionInStatusChange-=_OnConnectionInStatusChanged;
							explicitConnection.ConnectionInStatusChange+=_OnConnectionInStatusChanged;
						}
					}

				}

			}//for

			if(!_isAvailable){
				Debug.LogWarning("No OSCConnection that fit the settings! No OSCMessages will be received!");
			}

		}


		private void _DisconnectFromDispatchers()
		{
			//Debug.Log("UniOSCEventTargetCB._DisconnectFromDispatchers");
			foreach(var kvp in ConnectToDict){
				kvp.Key.OSCMessageReceived-= _OnOSCMessageReceived;
			}
			ConnectToDict.Clear();
			if(explicitConnection != null) explicitConnection.ConnectionInStatusChange-=_OnConnectionInStatusChanged;//saftey

		}

		private void _OnOSCMessageReceived(object sender,UniOSCEventArgs args)
		{
			//Debug.Log("UniOSCEventTargetCB._OnOSCMessageReceived");
			if(_isDispatchAble(args.Port,args.Address))
			{
				OnOSCMessageReceived(args);
				//sent out our event so that other classes are notified
				if(OSCMessageReceived != null) OSCMessageReceived(this, args);
			}

		}

		private void _OnConnectionInStatusChanged(UniOSCConnection con)
		{
			//Debug.Log("UniOSCEventTargetCB._OnConnectionInStatusChanged");

		}

		private bool _isDispatchAble(int port, string address){
			return ( useExplicitConnection || receiveAllPorts || oscPort == port) && ( receiveAllAddresses || _oscAddresses.Exists(adr => adr == address && !String.IsNullOrEmpty(address) ) );	 
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

		#endregion


		/// <summary>
		/// You should override this method in a subclass to handle the OSC data.
		/// </summary>
		/// <param name="args">The current OSCEventArgs object</param>
		public abstract void OnOSCMessageReceived(UniOSCEventArgs args) ;

	}
}
