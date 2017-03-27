using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class MP_InfoSync : Photon.MonoBehaviour {


    public TextMesh nameText;

    private PhotonPlayer _owner;

	// Use this for initialization
	void Start () {
        _owner = this.photonView.owner;
        nameText.text = _owner.NickName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
