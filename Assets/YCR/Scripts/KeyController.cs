using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        keyHandler();
	}

    void keyHandler () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            //atk
            Debug.Log("ATK");
        }
    }
}
