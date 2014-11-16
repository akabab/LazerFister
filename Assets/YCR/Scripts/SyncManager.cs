using UnityEngine;
using System.Collections;

public class SyncManager : Photon.MonoBehaviour
{
    private ThirdPersonController controllerScript;
    private Player player;

    void Awake()
    {
        controllerScript = GetComponent<ThirdPersonController>();
        player = GetComponent<Player>();

        if (photonView.isMine) {
            //MINE: local player, simply enable the local scripts
            controllerScript.enabled = true;
        } else {
            controllerScript.enabled = true;
            controllerScript.isControllable = false;
        }

        gameObject.name = gameObject.name + photonView.viewID;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting) {
            //We own this player: send the others our data
            stream.SendNext((int)controllerScript._characterState);
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(player.message);
        } else {
            //Network player, receive data
            controllerScript._characterState = (CharacterState)(int)stream.ReceiveNext();
            correctPlayerPos = (Vector3)stream.ReceiveNext();
            correctPlayerRot = (Quaternion)stream.ReceiveNext();
            player.message = (string)stream.ReceiveNext();
        }
    }

    private Vector3 correctPlayerPos = Vector3.zero; //We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; //We lerp towards this

    void Update()
    {
        if (!photonView.isMine) {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);
        }
    }

}