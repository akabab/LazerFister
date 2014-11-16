using UnityEngine;
using System.Collections;

public class ActionController : MonoBehaviour {

    public GameObject target;

    private PhotonView photonView;

	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
        Debug.Log(PhotonNetwork.player);
	}

	// Update is called once per frame
	void Update () {

	}

    void OnMouseUp () {
        if (!photonView.isMine)
        {
            target = this.gameObject;
        }
    }
}
