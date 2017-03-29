using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Lobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.isMessageQueueRunning = true;
        PhotonNetwork.Instantiate("playerRiggedDR", Vars.lobby, Quaternion.identity, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
