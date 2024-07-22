using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PhotonView), typeof(Throwable))]
public class Grabbable : MonoBehaviour
{
    private Throwable throwable { get => GetComponent<Throwable>();}
    private PhotonView photonView { get => GetComponent<PhotonView>();}

    public bool isGravity;
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = isGravity;
        
        throwable.onPickUp.AddListener(delegate {
            photonView.RequestOwnership();
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, true);
        });

        throwable.onDetachFromHand.AddListener(delegate {
            //photonView.RPC("CancelGravityRPC", RpcTarget.All, false);
        });
    }

    [PunRPC]
    public void CancelGravityRPC(bool cancelGravity)
    {
        Debug.Log("Gravity is " + (cancelGravity ? "canceled" : "enabled"));
    }
}
