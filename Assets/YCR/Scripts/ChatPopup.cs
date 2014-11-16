using UnityEngine;
using System.Collections;

public class ChatPopup : MonoBehaviour {

    private Player _player;
    private TextMesh _textMesh;

	// Use this for initialization
	void Start () {
        _player = transform.parent.GetComponent<Player>();
        _textMesh = GetComponent<TextMesh>();
    }

	// Update is called once per frame
	void Update () {
        _textMesh.text = _player.getMessage();
        transform.LookAt(Camera.main.transform);
	}
}
