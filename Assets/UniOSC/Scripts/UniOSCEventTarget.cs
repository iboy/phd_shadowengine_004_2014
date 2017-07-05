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
	/// UniOSC event target.
	/// This is the abstract class you should subclass from when you want to receive OSC data
	/// </summary>
	[ExecuteInEditMode]
	public abstract class UniOSCEventTarget : MonoBehaviour {

		#region public
		/// <summary>
		/// Occurs when the  OnOSCMessageReceived method iscalled.
		/// </summary>
		public event EventHandler<UniOSCEventArgs> OSCMessageReceived;

		[SerializeField,HideInInspector]
		public Dictionary<UniOSCConnection,List<UniOSCMappingItem>> ConnectToDict = new Dictionary<UniOSCConnection,List<UniOSCMappingItem>>();
		
		public  List<string> GetOSCAddresses{
					get{return _oscAddresses;}
		}

		[HideInInspector]
		public string oscAddress ;

		[HideInInspector]
		public bool receiveAllAddresses;	
		//public bool receiveAllAddresses{get{return _receiveAllAddresses;} set{_receiveAllAddresses = value;}}
			
		[HideInInspector]
		public bool useExplicitConnection;

		[HideInInspector]
		public UniOSCConnection explicitConnection;

		[HideInInspector]
		public int oscPort;
		

		[HideInInspector]
		public bool receiveAllPorts;

		#endregion

		#region protected

		[SerializeField,HideInInspector]
		protected List<string> _oscAddresses = new List<string>() ;

		[SerializeField,HideInInspector]
		protected bool _redrawFlag;

		[SerializeField,HideInInspector]
		protected List<UnityEngine.Object> _foldoutList  = new List<UnityEngine.Object>();

		#endregion


		public virtual void Start () {

		}

		public virtual void Update () {
	#if UNITY_EDITOR
			if(Application.isPlaying){
				_redrawFlag = !_redrawFlag;
			}
	#endif
		}


		protected void _OnConnectionInStatusChanged(UniOSCConnection con)
		{
			//Debug.Log("UniOSCEventTarget._OnConnectionInStatusChanged");
			//force refresh of status
			enabled = !enabled;
			enabled = !enabled;
		}



		/// <summary>
		/// Enable this component and reinitialize. If a property of the component is changed via the inspector we force a OnEnable to update the status of the component.
		/// In general the component disconnects from all OSCConnections and try to find a new OSCConnection to connect to with a matching port.
		/// If you change properties via code you should call this explicit.
		/// </summary>
		public virtual void OnEnable(){
			_Init();
		}

		private void _Init(){
			if(_oscAddresses.Count == 0 && !_oscAddresses.Contains(oscAddress)) _oscAddresses.Add(oscAddress);

			_DisconnectFromDispatchers();
			_ConnectToDispatchers();
		}

	

		protected void _ConnectToDispatchers(){
			//Debug.Log("UniOSCEventTarget._ConnectToDispatchers");

			if(UniOSCConnection.Instances == null)return;
							
			foreach(var con in UniOSCConnection.Instances){
			
				if(con == null)continue;

				if(useExplicitConnection)
				{
					if(explicitConnection == null)return;	
					if(con != explicitConnection ) continue;
				}

				if( useExplicitConnection == true || ( receiveAllPorts || con.oscPort == oscPort)){
				//if(  ( receiveAllPorts || con.oscPort == oscPort) ){
					if(!ConnectToDict.ContainsKey(con)){
						ConnectToDict.Add(con,new List<UniOSCMappingItem>());
						con.OSCMessageReceived-= _OnOSCMessageReceived;
						con.OSCMessageReceived+= _OnOSCMessageReceived;
						if( useExplicitConnection && explicitConnection != null){
							explicitConnection.ConnectionInStatusChange-=_OnConnectionInStatusChanged;
							explicitConnection.ConnectionInStatusChange+=_OnConnectionInStatusChanged;
						}
					}
					//we receive all so we don't display every mapping item in the gui
					if(receiveAllAddresses || !con.hasOSCMappingFileAttached ) continue;

				}else{

					continue;
				}
				//only for GUI to display what we are listening to
				foreach(var mdo in con.oscMappingFileObjList){
					if(mdo == null)continue;
					foreach(var d in mdo.oscMappingItemList){
						if(d== null)continue;
						if(_isDispatchAble(con.oscPort,d.address)){
							ConnectToDict[con].Add(d); 
						}
					}//d
				}//mdo


			}//con

		}
		
		protected void _DisconnectFromDispatchers(){

			foreach(var kvp in ConnectToDict){
				kvp.Key.OSCMessageReceived-= _OnOSCMessageReceived;
			}
			ConnectToDict.Clear();
			if(explicitConnection != null) explicitConnection.ConnectionInStatusChange-=_OnConnectionInStatusChanged;//saftey
		}



		public virtual void OnDestroy(){
			_DisconnectFromDispatchers();
		}

		/// <summary>
		/// When the component is disabled we disconnect from all OSCConnections and clear some internal data.
		/// </summary>
		public virtual void OnDisable(){
			//Debug.Log("UniOSCEventTarget.OnDisable");
			_DisconnectFromDispatchers();
			_oscAddresses.Clear();
		}

		/// <summary>
		/// A delegate which is normally called from a OSCConnection when a OSC message arrives.
		/// If the port and address matches with the OnOSCMessageReceived() method is called where you could handle the data
		/// </summary>
		/// <param name="args">The current OSCEventArgs object</param>
		private void _OnOSCMessageReceived(object sender,UniOSCEventArgs args){
			//Debug.Log("UniOSCEventTarget._OnDispatched:"+this.name);
			if(_isDispatchAble(args.Port,args.Address))
			{
				OnOSCMessageReceived(args);
				//sent out our event so that other classes are notified
				if(OSCMessageReceived != null) OSCMessageReceived(this, args);
			}
		}


		private bool _isDispatchAble(int port, string address){
			return ( useExplicitConnection || receiveAllPorts || oscPort == port) && ( receiveAllAddresses || _oscAddresses.Exists(adr => adr == address && !String.IsNullOrEmpty(address) ) );	 
		}

		/// <summary>
		/// You should override this method in a subclass to handle the OSC data.
		/// </summary>
		/// <param name="args">The current OSCEventArgs object</param>
		public abstract void OnOSCMessageReceived(UniOSCEventArgs args) ;


	}

}
