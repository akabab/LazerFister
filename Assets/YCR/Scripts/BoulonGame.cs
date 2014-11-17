using UnityEngine;
using System.Collections;

public class BoulonGame : Photon.MonoBehaviour {

    public GameObject boulon;
    public Vector2 mapSize;
    public int popDelay;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnJoinedRoom () {
        Debug.Log("I join");

        if (PhotonNetwork.isMasterClient) {
            Debug.Log("Im master");
            InvokeRepeating("popBoulon", 0, Random.Range(popDelay * 0.8f, popDelay * 1.2f));
        }
    }

    void popBoulon() {
        Vector3 pos = new Vector3(Random.Range(-(mapSize.x/2), mapSize.x/2), 5, Random.Range(-(mapSize.y/2), mapSize.y/2));
        PhotonNetwork.Instantiate(boulon.name, pos, Quaternion.identity, 0);
    }

}
