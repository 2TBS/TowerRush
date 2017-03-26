using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_PlayerManager : MonoBehaviour {

    public GameObject gui;
    public PhotonView photonView;
    // Use this for initialization
    void Awake()
    {
        if (photonView.isMine)
        {
            gui.SetActive(true);
            gameObject.GetComponent<Pl_MouseLook>().enabled = true;
            gameObject.GetComponent<Pl_Controller>().enabled = true;
            gameObject.GetComponent<InputManager>().enabled = true;
            gameObject.GetComponent<PhotonTransformView>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

        }
    }
}
